using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Dapper;
using Domain.AggregateRoots;
using Domain.Common;

namespace DAL
{
    public class BorrowOrderRepository: BaseRepository ,IBorrowOrderRepository
    {
        public BorrowOrderRepository(DataContext context) : base(TableNames.LibUserTableName, context) { }

        public async Task<IEnumerable<BorrowOrder>> GetAllAsync()
        {
            List<BorrowOrder> result = new List<BorrowOrder>();
            IEnumerable<int> ids;
            using (var conn = dataContext.CreateConnection())
            {
                ids = await conn.QueryAsync<int>("SELECT OrderID FROM [BorrowOrder]");
            }
            foreach (var id in ids)
            {
                result.Add(await GetByIdAsync(id));
            }
            return result;
        }

        public async Task<Result<BorrowOrder>> GetByIdAsync(int id)
        {
            LibUserRepository userRepository = new LibUserRepository(dataContext);
            ItemDescriptorRepository idRepository = new ItemDescriptorRepository(dataContext);
            BorrowOrder result;
            int borrowerID, librarianID, itemID;
            using (var conn = dataContext.CreateConnection())
            {
                result = await conn.QuerySingleAsync<BorrowOrder>("SELECT [OrderID], [BorrowDate], [ReturnDate] FROM [BorrowOrder] WHERE OrderID = @OrderID", new { OrderID = id });
                borrowerID = await conn.QuerySingleAsync<int>("SELECT [BorrowerSSN] FROM [BorrowOrder] WHERE OrderID = @OrderID", new { OrderID = id });
                librarianID = await conn.QuerySingleAsync<int>("SELECT [LibrarianSSN] FROM [BorrowOrder] WHERE OrderID = @OrderID", new { OrderID = id });
                itemID = await conn.QuerySingleAsync<int>("SELECT [ItemID] FROM [BorrowOrder] WHERE OrderID = @OrderID", new { OrderID = id });
            }
            result.Borrower = await userRepository.GetByIdAsync(borrowerID);
            result.Librarian = await userRepository.GetByIdAsync(librarianID);
            result.Item = await idRepository.GetItemByIdAsync(itemID);
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
