using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers.WebSite
{
    public class ExampleController : Controller
    {
        // GET: Example
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult AuthTest()
        {
            var user = HttpContext.User;
            return View();
        }


        public ActionResult GetAuthorizedData()
        {
            var values = new ApiClients.ValuesClient("http://localhost:50533/",this.GetToken()).GetValues();
            return new JsonResult { Data = values, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}