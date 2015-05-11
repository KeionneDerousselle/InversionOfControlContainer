using IOCContainerProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCContainerProject.Models
{
    public class RegisteredObject
    {
        public Type Interface { get; private set; }
        public Type Implementation { get; private set; }
        public LifestyleType Lifestyle { get; private set; }
        public object Instance { get; private set; }

        public RegisteredObject(Type Interface, Type Implementation, LifestyleType lifestyle)
        {
            this.Interface = Interface;
            this.Implementation = Implementation;
            this.Lifestyle = lifestyle;
        }

        public void CreateInstance(object[] parameters)
        {
            this.Instance = Activator.CreateInstance(Implementation, parameters);
        }
        
    }
}
