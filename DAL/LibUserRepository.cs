using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Domain.Entities;
using Dapper;
using System.Linq;
using Application.Contracts.Persistence;
using System.Threading.Tasks;
using Domain.AggregateRoots;
using Domain.Common;

namespace DAL
{
    public class LibUserRepository : BaseRepository ,ILibUserRepository
    {
        public LibUserRepository(DataContext context) : base(TableNames.LibUserTableName, context) { }

        public async Task<int> AddAsync(LibUser entity)
        {
            int id;
            //If the type is "NULL", the string will be set to null, so SQL would understand that it's actuall null value, not "null" string
            String MemberType = null;
            String LibrarianType = null;
            if (entity.MemberType.ToString() != "NULL") MemberType = entity.MemberType.ToString();
            if (entity.LibrarianType.ToString() != "NULL") LibrarianType = entity.LibrarianType.ToString();

            using (var conn = dataContext.CreateConnection())
            {
                id = await conn.QuerySingleAsync<int>
                    ($"INSERT INTO [LibUser] (SSN, FName, Surname, Address, Phone, Campus, MemberType, LibrarianType) OUTPUT inserted.SSN VALUES (@SSN, @FName, @Surname, @Address, @Phone, @Campus, @MemberType, @LibrarianType)",
                        new { SSN = entity.SSN, Fname = entity.FName, Surname = entity.Surname, Address = entity.Address, Phone = entity.Phone, Campus = entity.Campus, MemberType = MemberType, LibrarianType = LibrarianType });
            }

            return id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var conn = dataContext.CreateConnection())
            {
                int rowsAffected = await conn.ExecuteAsync("DELETE FROM [LibUser] WHERE SSN = @SSN", new { SSN = id });
                return rowsAffected;
            }
        }

        public async Task<IEnumerable<LibUser>> GetAllAsync()
        {
            using (var conn = dataContext.CreateConnection())
            {
                return await conn.QueryAsync<LibUser>("SELECT * FROM [LibUser]");
            }
        }

        public async Task<Result<LibUser>> GetByIdAsync(int id)
        {
            using (var conn = dataContext.CreateConnection())
            {
                return await conn.QuerySingleAsync<LibUser>("SELECT * FROM [LibUser] WHERE SSN = @SSN", new { SSN = id });
            }
        }

        public async Task<int> UpdateAsync(LibUser entity)
        {
            using (var conn = dataContext.CreateConnection())
            {
                //If the type is "NULL", the string will be set to null, so SQL would understand that it's actuall null value, not "null" string
                String MemberType = null;
                String LibrarianType = null;
                if (entity.MemberType.ToString() != "NULL") MemberType = entity.MemberType.ToString();
                if (entity.LibrarianType.ToString() != "NULL") LibrarianType = entity.LibrarianType.ToString();

                int rowsAffected = await conn.ExecuteAsync("UPDATE [LibUser] SET FName = @FName, Surname = @Surname, Address = @Address, Phone = @Phone, Campus = @Campus, MemberType = @MemberType, LibrarianType = @LibrarianType WHERE SSN = @SSN", new
                { FName = entity.FName, Surname = entity.Surname, Address = entity.Address, Phone = entity.Phone, Campus = entity.Campus, MemberType = MemberType, LibrarianType = LibrarianType, SSN = entity.SSN });

                return rowsAffected;
            }
        }
    }
}
