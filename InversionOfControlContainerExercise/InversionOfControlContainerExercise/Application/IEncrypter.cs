using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlContainerExercise.Application
{
    public interface IEncrypter
    {
        string EncryptPassword(string password);
    }
}
