using IOCContainerProject.Infrastructure;
using IOCContainerProject.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCContainerSpecs.Tests
{
    [TestFixture]
    public class IOCContainerTests
    {
        private static IOCContainer iocContainer;

        [TestFixtureSetUp]
        public void Init()
        {
            iocContainer = new IOCContainer();
        }

        [Test]
        public void TestRegisterValidDependency()
        {
            iocContainer.Register<INoiseMaker, Baby>();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage="You must register a type that implements the interface you passed in.")]
        public void TestRegisterInValidDependency()
        {
            iocContainer.Register<INoiseMaker, Librarian>();
        }
    }
}
