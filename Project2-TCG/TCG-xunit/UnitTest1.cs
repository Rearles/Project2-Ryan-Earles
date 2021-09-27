using Microsoft.EntityFrameworkCore;
using Project2_TCG.Controllers;
using Project2_TCG.Models;
using Project2_TCG.Models.Entities;
using System;
using Xunit;

namespace TCG_xunit
{
    public class UnitTest1
    {
        

        [Fact]
        public void Test1()
        {
            var options = new DbContextOptionsBuilder<cardgameContext>()
                .UseInMemoryDatabase(databaseName: "petadmin")
                .Options;

            using(var context = new cardgameContext(options))
            {
                context.Users.Add(new Project2_TCG.Models.Entities.User
                {
                    Username = "testingGuy",
                    Password = "password",
                });
                context.SaveChanges();

                CardRepo repo = new CardRepo(context);

                var user = new Project2_TCG.Models.User("testingGuy", "password");
                var result = repo.SearchUserById(1);

                Assert.Equal(user.Username, result.Username);
            }  
        }

        [Fact]
        public void test_for_user_controller_fetch()
        {
            var options = new DbContextOptionsBuilder<cardgameContext>()
                .UseInMemoryDatabase(databaseName: "petadmin")
                .Options;

            using (var context = new cardgameContext(options))
            {
                context.Users.Add(new Project2_TCG.Models.Entities.User
                {
                    Username = "testingGuy2",
                    Password = "password",
                });
                context.SaveChanges();

                CardRepo repo = new CardRepo(context);
                UserController userController = new UserController(repo);

                string expected = "testingGuy2";
                string result = userController.Username("testingGuy2");
                Assert.Equal(expected, result);
            }
        }

    }
}
