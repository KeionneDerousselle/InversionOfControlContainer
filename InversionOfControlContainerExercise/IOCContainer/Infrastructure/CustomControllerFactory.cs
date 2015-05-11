using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;
using System.Web.SessionState;
using System.Reflection;

namespace IOCContainerProject.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        private IIOCContainer container;
        public CustomControllerFactory(IIOCContainer container)
        {
            this.container = container;
        }
       
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            IController controller = null;
          
            controllerName = (Char.ToUpper(controllerName[0]) + controllerName.Substring(1));

            Type controllerType = getFirstTypeByName(controllerName+"Controller");

            if(controllerType == null)
            {
                controllerType = getFirstTypeByName(controllerName);
            }

            if (controllerType != null)
            {

                var resolveMethod = container.GetType().GetMethod("ResolveObjectContructorParamsTypes").MakeGenericMethod(new Type[] { controllerType });
                var parameters = resolveMethod.Invoke(container, new object[] { }) as IEnumerable<object>;

               /// var constructor = controllerType.GetConstructors().FirstOrDefault();
                //constructor.Invoke(parameters.ToArray) as IController;

                controller = Activator.CreateInstance(controllerType, parameters.ToArray()) as IController;
            }

            return controller;
        }

        public static Type getFirstTypeByName(string className)
        {
            Type returnVal = null;
            bool foundType = false;

            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                
                Type[] assemblyTypes = a.GetTypes();
                for (int j = 0; j < assemblyTypes.Length && !foundType; j++)
                {
                    if (assemblyTypes[j].Name == className)
                    {
                        returnVal = assemblyTypes[j];
                        foundType = true;
                    }
                }
            }

            return returnVal;
        }

        public void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;
            if(disposable != null)
            {
                disposable.Dispose();
            }
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }
    }
}
