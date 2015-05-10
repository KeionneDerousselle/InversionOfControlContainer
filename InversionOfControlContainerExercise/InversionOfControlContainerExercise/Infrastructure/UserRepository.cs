using InversionOfControlContainerExercise.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace InversionOfControlContainerExercise.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private static readonly string USERS_SAVE_LOCATION = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/PersistedUsers/AllUsers.txt";

        public UserRepository(){}

        public User GetAuthenticatedUser(string username, string password)
        {
            List<User> users = GetAllUsers();
            User u = users.Where(x => x.Username.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
            return u;
        }

        public void Create(User user)
        {
            List<User> users = GetAllUsers();
            users.Add(user);
            using (var stream = File.Open(USERS_SAVE_LOCATION, FileMode.Create))
            {
                new BinaryFormatter().Serialize(stream, users);
            }
        }

        private List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using(var stream = File.Open(USERS_SAVE_LOCATION, FileMode.OpenOrCreate))
            {
                if(stream.Length > 0)
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    users = (List<User>)binaryFormatter.Deserialize(stream);
                }
            }

            return users;
        }
    }
}