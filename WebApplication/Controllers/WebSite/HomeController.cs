using Database.Repositories;
using Database.Repositories.Excercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        //Przykład wstrzykiwania repo
        IExcerciseRepository repo;

        public HomeController(IExcerciseRepository repo)
        {
            this.repo = repo;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
