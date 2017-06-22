using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers.WebSite
{
    public class ExcerciseController : Controller
    {
        // GET: Excercise
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddExercise()
        {
            return View();
        }
    }
}