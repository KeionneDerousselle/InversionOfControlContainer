using InversionOfControlContainerExercise.Application;
using InversionOfControlContainerExercise.Infrastructure;
using IOCContainerProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace InversionOfControlContainerExercise
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigurationSettings.AppSettings["users_save_location"] = AppDomain.CurrentDomain.BaseDirectory + "PersistedUsers/allUsers.txt";

            var container = new IOCContainer();

            container.Register<IAuthenticationApplication, AuthenticationApplication>();
            container.Register<IUserRepository, UserRepository>();
            container.Register<IEncrypter, Encrypter>();

            var factory = new CustomControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(factory);

        }
    }
}
