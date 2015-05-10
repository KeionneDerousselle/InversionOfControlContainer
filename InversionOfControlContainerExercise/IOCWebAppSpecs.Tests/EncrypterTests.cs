using InversionOfControlContainerExercise.Application;
using InversionOfControlContainerExercise.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCWebAppSpecs.Tests
{
    [TestFixture]
   public class EncrypterTests
    {
        private static Encrypter encrypter;

        [TestFixtureSetUp]
        public void Init()
        {
            encrypter = new Encrypter();
        }

        [Test]
        public void TestEncryptPassword()
        {
           string originalPassword = "fooPass";
           string encryptedPassword = "";

           encryptedPassword = encrypter.EncryptPassword(originalPassword);

           Assert.That(!string.IsNullOrEmpty(originalPassword));
           Assert.That(!encryptedPassword.Equals(originalPassword));
        }
    }
}
