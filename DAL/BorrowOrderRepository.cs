using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Dapper;
using Domain.AggregateRoots;
using Domain.Common;
using Domain.Entities;

namespace DAL
{
    public class BorrowOrderRepository: BaseRepository ,IBorrowOrderRepository
    {
        public BorrowOrderRepository(DataContext context) : base(TableNames.LibUserTableName, context) { }

        public async Task<IEnumerable<BorrowOrder>> GetAllAsync()
        {
            IEnumerable<BorrowOrder> result = new List<BorrowOrder>();
            var sql = "SelectAllOrders";

            using (var conn = dataContext.CreateConnection())
            {
                IEnumerable<BorrowOrder> orders = await conn.QueryAsync<BorrowOrder, LibUser, LibUser, Item, ItemDescriptor,BorrowOrder>
                    (sql, (order, borrower, librarian, item, itemDesccriptor) =>
                    {
                        order.Borrower = borrower;
                        order.Librarian = librarian;
                        order.Item = item;
                        order.Item.ItemDescriptor = itemDesccriptor;
                        return order;
                    }, splitOn: "SSN,SSN,ItemID,ID");
                result = orders;
            }
            return result;
        }

        public async Task<Result<BorrowOrder>> GetByIdAsync(int id)
        {
            BorrowOrder result;
            var sql = $"SelectOrderById {id}";
            using (var conn = dataContext.CreateConnection())
            {
                var data = await conn.QueryAsync<BorrowOrder, LibUser, LibUser, Item, ItemDescriptor, BorrowOrder>
                    (sql, (order, borrower, librarian, item, itemDesccriptor) =>
                    {
                        order.Borrower = borrower;
                        order.Librarian = librarian;
                        order.Item = item;
                        order.Item.ItemDescriptor = itemDesccriptor;
                        return order;
                    }, splitOn: "SSN,SSN,ItemID,ID");
                result = data.First();
            }
            return result;
        }

        public async Task<int> AddAsync(BorrowOrder entity)
        {
            using (var conn = dataContext.CreateConnection())
            {
                return await conn.QuerySingleAsync<int>("INSERT [BorrowOrder] OUTPUT inserted.OrderId VALUES(@BorrowDate, NULL, @BorrowerSSN, @LibrarianSSN, @ItemID)",
                    new { BorrowDate = entity.BorrowDate, BorrowerSSN = entity.Borrower.SSN, LibrarianSSN = entity.Librarian.SSN, ItemID = entity.Item.ItemID });
            }
        }

        public async Task<int> UpdateAsync(BorrowOrder entity)
        {
            using (var conn = dataContext.CreateConnection())
            {
                return await conn.ExecuteAsync("UPDATE [BorrowOrder] SET ReturnDate = @ReturnDate WHERE OrderID = @ID", new { ID = entity.OrderID, ReturnDate = entity.ReturnDate });
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var conn = dataContext.CreateConnection())
            {
                return await conn.ExecuteAsync("DELETE FROM [BorrowOrder] WHERE OrderID = @ID", new { ID = id });
            }
        }

        public async Task<int> GetCountOfUnreturnedOrders(int userSSN)
        {
            using (var conn = dataContext.CreateConnection())
            {
                return await conn.QuerySingleAsync<int>("dbo.GetNumberOfBorrowedBooksByUserId @id", new { id = userSSN});
            }
        }
        public async Task<IEnumerable<BorrowOrder>> GetAllOngoingBorrowOrdersAsync()
        {
            List<BorrowOrder> result = new List<BorrowOrder>();
            IEnumerable<int> ids;
            using (var conn = dataContext.CreateConnection())
            {
                ids = await conn.QueryAsync<int>("SELECT [OrderId] FROM [BorrowOrder] WHERE ReturnDate IS NULL");
            }
            foreach (var id in ids)
            {
                result.Add(await GetByIdAsync(id));
            }
            return result;
        }

    }
}
