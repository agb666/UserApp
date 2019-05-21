using System;
using UserApp.Models;
using Xunit;
using System.Data;
using System.Data.SqlClient;

namespace UserApp.Tests
{
    public class DataLayerTests
    {
        [Fact]
        public void InsertUser()
        {
            var u = new User();
            u.Email = "UNITTEST";
            u.Password = "UNITTEST";
            var d = new UserDataAccessLayer();
            d.AddUser(u.Email, u.Password);
            Assert.True(d.AddUser(u.Email, u.Password));
        }
    }
}
