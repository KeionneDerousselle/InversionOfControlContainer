using IOCContainerProject.Exceptions;
using IOCContainerProject.Infrastructure;
using IOCContainerSpecs.Tests.TestingModels;
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

        [Test]
        public void TestResolveValidDependency()
        {
            object returnedInstance = null;

            iocContainer.Register<INoiseMaker, Baby>();
            returnedInstance = iocContainer.Resolve<INoiseMaker>();

            Assert.That(returnedInstance is INoiseMaker);
            Assert.That(returnedInstance is Baby);
        }

        [Test]
        [ExpectedException(typeof(TypeNotRegisteredException), ExpectedMessage = "The type, INoiseMaker, has not been registered.")]
        public void TestResolveInValidDependency()
        {
            object returnedInstance = null;

            iocContainer.Register<IAnimal, Duck>();
            returnedInstance = iocContainer.Resolve<INoiseMaker>();

            Assert.That(returnedInstance == null);
        }
    }
}
