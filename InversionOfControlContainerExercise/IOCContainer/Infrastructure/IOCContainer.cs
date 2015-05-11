using IOCContainerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCContainerProject.Infrastructure
{
    public class IOCContainer : IIOCContainer
    {
        private readonly IList<RegisteredObject> registeredObjects = new List<RegisteredObject>();
        public void Register<TInterface, TImplementation>(LifestyleType lifestyle = LifestyleType.Transient)
        {
            if(typeof(TInterface).IsAssignableFrom(typeof(TImplementation)))
            {
                registeredObjects.Add(new RegisteredObject(typeof(TInterface), typeof(TImplementation), lifestyle));
            }
            else
            {
                throw new ArgumentException("You must register a type that implements the interface you passed in.");
            }
        }
    }
}
