using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;
using System.Web.SessionState;

namespace IOCContainerProject.Infrastructure
{
    public class CustomControllerFactory
    {
        //public IController CreateController(RequestContext requestContext, string controllerName)
        //{
        //    if(controllerName.ToLower().StartsWith("authentication"))
        //    {
        //       // var controller = new AuthenticationController();
        //    }
        //}

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            throw new NotImplementedException();
        }

        public void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;
            if(disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}
