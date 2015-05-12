using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InversionOfControlContainerExercise.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public ActionResult Index()
        {
            return View("~/Views/Shared/application.cshtml");
        }

        public ActionResult DropDownNav()
        {
            return View("~/Views/Shared/DropDownNav.cshtml");
        }
    }
}