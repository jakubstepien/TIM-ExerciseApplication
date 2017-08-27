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
        [Route("", Order = -1)]
        [Route("{*url}", Order = 1000)]
        public ActionResult Index()
        {
            return View("index");
        }
    }
}
