using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCContainerProject.Infrastructure
{
    public interface IIOCContainer
    {
        void Register<TInterface, TImplementation>(LifestyleType lifestyle = LifestyleType.Transient);
        TInterface Resolve<TInterface>();
    }
}
