using InversionOfControlContainerExercise.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InversionOfControlContainerExercise.Application
{
    public class AuthenticationApplication :IAuthenticationApplication
    {
        private IUserRepository userRepo;
        public AuthenticationApplication()
        {
            this.userRepo = new UserRepository();
        }
        public bool UserIsValid(string username, string password)
        {
            return userRepo.GetAuthenticatedUser(username, password) != null;
        }
    }
}