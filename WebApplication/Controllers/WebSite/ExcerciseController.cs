using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Services;

namespace WebApplication.Controllers.WebSite
{
    public class ExcerciseController : Controller
    {
        ImageService imageService;

        public ExcerciseController(ImageService imageService)
        {
            this.imageService = imageService;
        }

        // GET: Excercise
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase ImageName, Guid IdExercise)
        {
            if (ImageName != null)
            {
                var succes = imageService.SaveImage(Server, ImageName, IdExercise);
                return Json(new { Success = succes });

            }
            return Json(new { Success = false });

        }
    }
}