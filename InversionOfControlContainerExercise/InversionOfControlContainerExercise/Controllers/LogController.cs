using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InversionOfControlContainerExercise.Controllers
{
    public class LogController : Controller
    {
        // GET: Log
        public ActionResult Index()
        {
            return View("~/Views/Log/MyLog.cshtml");
        }

        public ActionResult LogAMeal()
        {
            return View("~/Views/Log/LogAMeal.cshtml");
        }

        public ActionResult LogExercise()
        {
            return View("~/Views/Log/LogExercise.cshtml");
        }
    }
}