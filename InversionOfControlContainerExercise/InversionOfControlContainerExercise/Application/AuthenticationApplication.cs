using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InversionOfControlContainerExercise.Application
{
    public class AuthenticationApplication :IAuthenticationApplication
    {
        public bool UserIsValid(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}