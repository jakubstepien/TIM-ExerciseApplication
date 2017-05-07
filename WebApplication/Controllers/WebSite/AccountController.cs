using ApiClients;
using Database;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers.WebSite
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Register(RegisterBindingModel model)
        {

            return Redirect("/");
        }

        [HttpPost]
        public ActionResult Login(LoginBindingModel model, string returnUrl = "/")
        {
            if (TryValidateModel(model))
            {
                var identitiy = HttpContext.User;
                var token = new AccountClient().GetToken(model.Email, model.Password);
                if (!string.IsNullOrEmpty(token))
                {
                    UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new Providers.GuidUserStore(new ApplicationDbContext()));

                    var user = userManager.Find(model.Email, model.Password);

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identity = userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie).Result;
                    identity.AddClaim(new Claim(ControllerHelper.TokenClaimType, token));
                    authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);
                    return Redirect(returnUrl);
                }
            }

            return View(model);
        }

        public ActionResult SignOut()
        {
            var user = this.HttpContext.User;
            HttpContext.GetOwinContext().Authentication.SignOut(HttpContext.GetOwinContext()
                           .Authentication.GetAuthenticationTypes()
                           .Select(o => o.AuthenticationType).ToArray());

            return new EmptyResult();
        }
    }
}