using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InversionOfControlContainerExercise.Application;
using InversionOfControlContainerExercise.Models;
using NUnit.Framework;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace IOCWebAppSpecs.Tests
{
    [TestFixture]
    public class AuthenticationApplicationTests
    {
        private static readonly string USERS_SAVE_LOCATION = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/PersistedUsers/AllUsers.txt";
        private static AuthenticationApplication authenticationApp;
        private static User savedUser = new User
        {
            Id = "123",
            Name = "Foo",
            Username = "fooUser",
            Password = "fooPass",
            Weight = 150,
            Gender = Gender.FEMALE,
            DailyCaloricIntake = 1750,
            Log = new Log()
        };

        private static User newUser = new User
        {
            Id = "456",
            Name = "Bar",
            Username = "barUser",
            Password = "barPass",
            Weight = 180,
            Gender = Gender.MALE,
            DailyCaloricIntake = 2050,
            Log = new Log()
        };

        [TestFixtureSetUp]
        public void Init()
        {
            authenticationApp = new AuthenticationApplication();
            List<User> allUsers = new List<User> { savedUser };
            using (var stream = File.Open(USERS_SAVE_LOCATION, FileMode.Create))
            {
                new BinaryFormatter().Serialize(stream, allUsers);
            }
        }

        [Test]
        public void TestUserIsValidWithValidUser()
        {
            Assert.True(authenticationApp.UserIsValid(savedUser.Username, savedUser.Password));
        }

        [Test]
        public void TestUserIsValidWithInValidUser()
        {
            Assert.False(authenticationApp.UserIsValid(newUser.Username, newUser.Password));
        }

    }
}
