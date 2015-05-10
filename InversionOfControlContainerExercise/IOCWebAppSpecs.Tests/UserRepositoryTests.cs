using InversionOfControlContainerExercise.Infrastructure;
using InversionOfControlContainerExercise.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace IOCWebAppSpecs.Tests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private static readonly string USERS_SAVE_LOCATION = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/PersistedUsers/AllUsers.txt";
        private static UserRepository userRepo;
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
            userRepo = new UserRepository();
            List<User> allUsers = new List<User> { savedUser };
            using (var stream = File.Open(USERS_SAVE_LOCATION, FileMode.Create))
            {
                new BinaryFormatter().Serialize(stream, allUsers);
            }
        }

        [Test]
        public void TestGetAuthenticatedUser()
        {
            User returnedUser = null;
            returnedUser = userRepo.GetAuthenticatedUser(savedUser.Username, savedUser.Password);
            Assert.That(returnedUser.Equals(savedUser));
        }

    }
}
