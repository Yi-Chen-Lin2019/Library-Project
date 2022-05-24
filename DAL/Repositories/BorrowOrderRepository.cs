using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.AggregateRoots;
using Domain.Common;
using Dapper;
using DAL;

namespace DAL.Repositories
{
    public class BorrowOrderRepository
    {
        DBConnection db;
        public BorrowOrderRepository(){ db = new DBConnection(); }
        public async Task<IEnumerable<BorrowOrder>> GetAllAsync()
        {
            List<BorrowOrder> result = new List<BorrowOrder>();
            IEnumerable<int> ids;
            using (var conn = db.NewConnection())
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
            UserRepository userRepository = new UserRepository();
            ItemDescriptorRepository idRepository = new ItemDescriptorRepository();
            BorrowOrder result;
            int borrowerID, librarianID, itemID;
            using(var conn = db.NewConnection())
            {
                result = await conn.QuerySingleAsync<BorrowOrder>("SELECT [OrderID], [BorrowDate], [ReturnDate] FROM [BorrowOrder] WHERE OrderID = @OrderID", new { OrderID = id });
                borrowerID = await conn.QuerySingleAsync<int>("SELECT [BorrowerSSN] FROM [BorrowOrder] WHERE OrderID = @OrderID", new { OrderID = id });
                librarianID = await conn.QuerySingleAsync<int>("SELECT [LibrarianSSN] FROM [BorrowOrder] WHERE OrderID = @OrderID", new { OrderID = id });
                itemID = await conn.QuerySingleAsync<int>("SELECT [ItemID] FROM [BorrowOrder] WHERE OrderID = @OrderID", new { OrderID = id });
            }
            result.Borrower = await userRepository.GetByIdAsync(borrowerID);
            result.Librarian = await userRepository.GetByIdAsync(librarianID);
            result.Item = await idRepository.GetItemByIdAsync(itemID);
        }

        public async Task<int> AddAsync(BorrowOrder entity)
        {
            using (var conn = db.NewConnection())
            {
                return await conn.ExecuteAsync("INSERT [BorrowOrder] OUTPUT inserted.id VALUES(@BorrowDate, NULL, @BorrowerSSN, @LibrarianSSN, @ItemID)",
                    new { BorrowDate = entity.BorrowDate, BorrowerSSN = entity.Borrower.SSN, LibrarianSSN = entity.Librarian.SSN, ItemID = entity.Item.ItemID});
            }
        }

        public async void UpdateAsync(BorrowOrder entity)
        {
            using(var conn = db.NewConnection())
            {
                await conn.ExecuteAsync("UPDATE [BorrowOrder] SET ReturnDate = @ReturnDate", new { ReturnDate = entity.ReturnDate });
            }
        }

        public async void DeleteAsync(int id)
        {
            using(var conn = db.NewConnection())
            {
                await conn.ExecuteAsync("DELETE FROM [BorrowOrder] WHERE OrderID = @ID", new { ID = id });
            }
        }
    }
}
