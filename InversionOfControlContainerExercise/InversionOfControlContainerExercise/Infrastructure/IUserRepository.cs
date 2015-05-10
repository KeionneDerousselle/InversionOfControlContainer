using InversionOfControlContainerExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlContainerExercise.Infrastructure
{
    public interface IUserRepository
    {
        User GetAuthenticatedUser(string username, string password);
        void Create(User user);
    }
}
