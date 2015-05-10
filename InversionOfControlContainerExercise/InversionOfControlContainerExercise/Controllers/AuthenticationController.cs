using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InversionOfControlContainerExercise.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Index()
        {
            return View("~/Views/Authentication/Authenticate.cshtml");
        }
        public ActionResult Login()
        {
            return View("~/Views/Authentication/Login.cshtml");
        }

        public ActionResult Register()
        {
            return View("~/Views/Authentication/Register.cshtml");
        }
    }
}