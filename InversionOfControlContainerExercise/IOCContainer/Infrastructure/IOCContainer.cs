using IOCContainerProject.Exceptions;
using IOCContainerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public TInterface Resolve<TInterface>()
        {
            return (TInterface)ResolveHelper<TInterface>();
        }

        private object ResolveHelper<TInterface>()
        {
            RegisteredObject registeredObject = registeredObjects.Where(x => x.Interface == typeof(TInterface)).FirstOrDefault();
            if(registeredObject == null)
            {
                throw new TypeNotRegisteredException("The type, " + typeof(TInterface).Name + ", has not been registered.");
            }

            return GetInstanceOfObject(registeredObject);
        }

        private object GetInstanceOfObject(RegisteredObject registeredObject)
        {
            if(registeredObject.Instance == null 
                || registeredObject.Lifestyle == LifestyleType.Transient)
            {
                IEnumerable<object> parameters = ResolveObjectContructorParamsTypes(registeredObject);
                registeredObject.CreateInstance(parameters.ToArray());
            }

            return registeredObject.Instance;
        }

        public IEnumerable<object> ResolveObjectContructorParamsTypes<TImplemented>()
        {
            ConstructorInfo constructorInfo = typeof(TImplemented).GetConstructors().FirstOrDefault();

            foreach (var parameter in constructorInfo.GetParameters())
            {
                var resolveHelperMethod = this.GetType().GetMethod("ResolveHelper", BindingFlags.NonPublic | BindingFlags.Instance).MakeGenericMethod(new Type[] { parameter.ParameterType });
                yield return resolveHelperMethod.Invoke(this, new object[] { });
            }           
        }

        private IEnumerable<object> ResolveObjectContructorParamsTypes(RegisteredObject registerdObject)
        {
           ConstructorInfo constructorInfo = registerdObject.Implementation.GetConstructors().FirstOrDefault();
           
           foreach(var parameter in constructorInfo.GetParameters())
           {
               var resolveHelperMethod = this.GetType().GetMethod("ResolveHelper", BindingFlags.NonPublic | BindingFlags.Instance).MakeGenericMethod(new Type[] { parameter.ParameterType });
               yield return resolveHelperMethod.Invoke(this, new object[]{});
           }
            
        }
    }
}
