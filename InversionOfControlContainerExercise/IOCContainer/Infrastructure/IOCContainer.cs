using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCContainerProject.Infrastructure
{
    public class IOCContainer : IIOCContainer
    {
        public void Register<TInterface, TImplementation>(LifetyleType lifestyle = LifetyleType.Transient)
        {
            throw new NotImplementedException();
        }
    }
}
