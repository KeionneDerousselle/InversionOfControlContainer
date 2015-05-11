using InversionOfControlContainerExercise.Infrastructure;
using InversionOfControlContainerExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InversionOfControlContainerExercise.Application
{
    public class AuthenticationApplication :IAuthenticationApplication
    {
        private IUserRepository userRepo;
        private IEncrypter encrypter;
        public AuthenticationApplication(IUserRepository userRepo, IEncrypter encrypter)
        {
            this.userRepo = userRepo;
            this.encrypter = encrypter;
        }
        public bool UserIsValid(string username, string password)
        {
            return userRepo.GetAuthenticatedUser(username, encrypter.EncryptPassword(password)) != null;
        }
        public void Register(User user)
        {
            user.Password = encrypter.EncryptPassword(user.Password);
            userRepo.Create(user);
        }
    }
}