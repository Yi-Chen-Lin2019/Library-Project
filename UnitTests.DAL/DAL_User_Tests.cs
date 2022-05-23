using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using Domain.AggregateRoots;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.DAL
{
    [TestClass]
    public class DAL_User_Tests
    {
        [TestMethod]
        public void CheckConnection()
        {
            var dbConnection = new DBConnection();

            var result = dbConnection.ConnectionState();

            Assert.AreEqual("Open", result);
        }
        [TestMethod]
        public void UserTests()
        {
            //Test have to be run in order!
            //Sub test will return 0 is true, 1 if false
            //resul is summed, if any test failed, result will be higher

            Assert.IsTrue(UserAdd());
            Assert.IsTrue(UpdateUser());
            Assert.IsTrue(FindUser());
            Assert.IsTrue(DeleteUser());
        }

        private bool UserAdd()
        {
            var UserRepository = new UserRepository();

            LibUser libUser = new LibUser(1, "Jan", "Zadlewski", "Chrzaszczeszowice", 666, "Oxford");
            var result = UserRepository.AddAsync(libUser);

            if (1 == result.Result) return true;
            else return false;
        }


        private bool UpdateUser()
        {
            var UserRepository = new UserRepository();

            LibUser user = new LibUser(1, "Jan", "Walenski", "Chrzaszczeszowice", 666, "Oxford");
            var result = UserRepository.UpdateAsync(user);

            if (1 == result.Result) return true;
            else return false;
        }


        private bool FindUser()
        {
            var UserRepository = new UserRepository();
            LibUser user = UserRepository.GetByIdAsync(1).Result;

            if ("Jan" == user.FName) return true;
            else return false;
        }

        private bool DeleteUser()
        {
            var UserRepository = new UserRepository();
            int result = UserRepository.DeleteAsync(1).Result;

            if (result > 0) return true;
            else return false;
        }

        [TestMethod]
        public void GetAllUsers()
        {
            var UserRepository = new UserRepository();
            List<LibUser> users = UserRepository.GetAllAsync().Result.ToList();

            Assert.IsTrue(users.Count > 0);
        }
    }
}
