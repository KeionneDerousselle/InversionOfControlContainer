using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlContainerExercise.Application
{
    public interface IAuthenticationApplication
    {
        public bool UserIsValid(string username, string password);
    }
}
