using InversionOfControlContainerExercise.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InversionOfControlContainerExercise.Controllers
{
    public class AuthenticationController : Controller
    {
        private IAuthenticationApplication authenticationApplication;
        public AuthenticationController()
        {
            authenticationApplication = new AuthenticationApplication();
        }
        // GET: Authentication
        [HttpGet]
        public ActionResult Index()
        {
            return View("~/Views/Authentication/Authenticate.cshtml");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View("~/Views/Authentication/Login.cshtml");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View("~/Views/Authentication/Register.cshtml");
        }
        [HttpPost]
        public ActionResult LoginUser()
        {
            ActionResult result = null;
            string username = Request.Form["username"];
            string password = Request.Form["password"];

            if(username != null && username.Length > 0 
               && password!= null && password.Length > 0 
               && authenticationApplication.UserIsValid(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, false);
                result = View("~/Views/Log/MyLog.cshtml");
            }
            else
            {
                result = View("~/Views/Authentication/Authenticate.cshtml");
            }
            return result;
        }
    }
}