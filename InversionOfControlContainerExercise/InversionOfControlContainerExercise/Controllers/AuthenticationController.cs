using InversionOfControlContainerExercise.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using InversionOfControlContainerExercise.Models;

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

            if (username != null && username.Length > 0
               && password != null && password.Length > 0
               && authenticationApplication.UserIsValid(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, false);

                result = Redirect("/calorieTracker/myLog");
            }
            else
            {
                result = Redirect("/calorieTracker/authenticate");
            }
            return result;
        }

        public ActionResult RegisterUser()
        {
            bool validFormat = false;

            ActionResult result = null;

            User user = null;

            string name = Request.Form["name"];
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            string weightValue = Request.Form["weight"];
            string genderValue = Request.Form["gender"];
            int weight = 0;
            Gender gender = Gender.FEMALE;

            if (username != null && username.Length > 0)
            {
                if (password != null && password.Length > 0)
                {
                    if(int.TryParse(weightValue, out weight))
                    {
                        try
                        {
                            gender = (Gender) Enum.Parse(typeof(Gender), genderValue.ToUpper());

                            validFormat = true;

                            user = new User {Name = name, Username = username, Password = password, Weight = weight, Gender = gender };

                            authenticationApplication.Register(user);
                            FormsAuthentication.SetAuthCookie(username, false);
                            result = Redirect("/calorieTracker/myLog");
                        }
                        catch(Exception e)
                        {
                           
                        }
                    }

                }
            }

            if(!validFormat)
            {
                result = Redirect("/calorieTracker/authenticate");
            }
            return result;
        }
    }
}