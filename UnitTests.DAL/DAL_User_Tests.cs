using DAL;
using Domain.AggregateRoots;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace UnitTests.DAL
{
    public class DAL_User_Tests
    {
        public IConfiguration Configuration { get; }
        public DataContext dataContext { get; set; }
        public LibUserRepository UserRepository { get; set; }

        public DAL_User_Tests()
        {
            string connectionString = "Server=localhost,1433;User Id=sa;Password=MyPass@word;Database=LibraryDatabase;MultipleActiveResultSets=true";
            dataContext = new DataContext(connectionString);
            UserRepository = new LibUserRepository(dataContext);
        }

        [Fact]
        public void UserTests()
        {
            //Test have to be run in order!
            //Sub test will return 0 is true, 1 if false
            //resul is summed, if any test failed, result will be higher

            Assert.True(UserAdd());
            Assert.True(UpdateUser());
            Assert.True(FindUser());
            Assert.True(DeleteUser());
        }

        private bool UserAdd()
        {
            LibUser libUser = new LibUser(1, "Jan", "Zadlewski", "Chrzaszczeszowice", 666, "Oxford");
            var result = UserRepository.AddAsync(libUser);

            if (1 == result.Result) return true;
            else return false;
        }


        private bool UpdateUser()
        {
            LibUser user = new LibUser(1, "Jan", "Walenski", "Chrzaszczeszowice", 666, "Oxford");
            var result = UserRepository.UpdateAsync(user);

            if (1 == result.Result) return true;
            else return false;
        }


        private bool FindUser()
        {
            LibUser user = UserRepository.GetByIdAsync(1).Result;

            if ("Jan" == user.FName) return true;
            else return false;
        }

        private bool DeleteUser()
        {
            int result = UserRepository.DeleteAsync(1).Result;

            if (result > 0) return true;
            else return false;
        }

        [Fact]
        public void GetAllUsers()
        {
            List<LibUser> users = UserRepository.GetAllAsync().Result.ToList();

            Assert.True(users.Count > 0);
        }
    }
}
