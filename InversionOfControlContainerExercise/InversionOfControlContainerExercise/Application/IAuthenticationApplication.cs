using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlContainerExercise.Application
{
    public interface IAuthenticationApplication
    {
        bool UserIsValid(string username, string password);
    }
}
