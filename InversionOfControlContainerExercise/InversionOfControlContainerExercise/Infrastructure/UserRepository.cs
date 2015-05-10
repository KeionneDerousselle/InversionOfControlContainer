using InversionOfControlContainerExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InversionOfControlContainerExercise.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        public User GetAuthenticatedUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}