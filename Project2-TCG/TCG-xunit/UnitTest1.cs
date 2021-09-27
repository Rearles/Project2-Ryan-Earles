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

        [Fact]
        public void add_user_control()
        {
            var options = new DbContextOptionsBuilder<cardgameContext>()
                .UseInMemoryDatabase(databaseName: "petadmin")
                .Options;

            using (var context = new cardgameContext(options))
            {
                context.Users.Add(new Project2_TCG.Models.Entities.User
                {
                    Username = "testingGuy3",
                    Password = "password",
                });
                context.SaveChanges();

                CardRepo repo = new CardRepo(context);
                UserController userController = new UserController(repo);

                var expected = new CreatedUser("testingGuy4", "testingGuy4");
                var result = userController.Post(new CreatedUser("testingGuy4", "testingGuy4"));
                Assert.Equal(expected.username, result.username);
            }
        }

        [Fact]
        public void test_for_registration_success()
        {
            var options = new DbContextOptionsBuilder<cardgameContext>()
                .UseInMemoryDatabase(databaseName: "petadmin")
                .Options;

            using (var context = new cardgameContext(options))
            {
                context.Users.Add(new Project2_TCG.Models.Entities.User
                {
                    Username = "testingGuy4",
                    Password = "password",
                });
                context.SaveChanges();

                CardRepo repo = new CardRepo(context);
                UserController userController = new UserController(repo);

                var expected = new CreatedUser("testingGuy4", "password");
                var result = userController.Post(new CreatedUser("testingGuy4", "password"));
                Assert.Equal(expected.username, result.username);
            }
        }

        [Fact]
        public void login_success_test()
        {
            var options = new DbContextOptionsBuilder<cardgameContext>()
                .UseInMemoryDatabase(databaseName: "petadmin")
                .Options;

            using (var context = new cardgameContext(options))
            {
                context.Users.Add(new Project2_TCG.Models.Entities.User
                {
                    Username = "testingGuy5",
                    Password = "password",
                });
                context.SaveChanges();

                CardRepo repo = new CardRepo(context);
                LoginController loginController = new LoginController(repo);

                var expected = new LoggedInUser
                {
                    username = "testingGuy5",
                    password = "password"
                };

                var result = loginController.Post(new LoggedInUser
                {
                    username = "testingGuy5",
                    password = "password"
                });
                Assert.Equal(expected.username, result.Username);
            }
        }
    }
}
