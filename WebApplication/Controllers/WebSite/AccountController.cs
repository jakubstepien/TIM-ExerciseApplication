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

        [HttpPost]
        public ActionResult Register(RegisterBindingModel model)
        {
            if (TryValidateModel(model))
            {
                var client = new AccountClient();
                client.Register(new ApiClients.Models.Account.RegisterRequest { ConfirmPassword = model.ConfirmPassword, Email = model.Email, Password = model.Password });
                if (SignIn(model.Email, model.Password))
                {
                    return Redirect("/");
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginBindingModel model, string returnUrl = "/")
        {
            if (TryValidateModel(model))
            {
                var identitiy = HttpContext.User;
                var token = new AccountClient().GetToken(model.Email, model.Password);
                if (token.Success)
                {
                    Login(model.Email, model.Password, token.Data);
                    return Redirect(returnUrl);
                }
            }

            return View(model);
        }

        private bool SignIn(string email, string password)
        {
            var identitiy = HttpContext.User;
            var token = new AccountClient().GetToken(email, password);
            if (token.Success)
            {
                Login(email, password, token.Data);
                return true;
            }
            return false;
        }

        private void Login(string email, string password, string token)
        {
            UserManager<ApplicationUser, Guid> userManager = new UserManager<ApplicationUser, Guid>(new Providers.GuidUserStore(new ApplicationDbContext()));

            var user = userManager.Find(email, password);

            var authManager = HttpContext.GetOwinContext().Authentication;
            var identity = userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie).Result;
            identity.AddClaim(new Claim(ControllerHelper.TokenClaimType, token));
            authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);
        }

        public ActionResult SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(HttpContext.GetOwinContext()
                           .Authentication.GetAuthenticationTypes()
                           .Select(o => o.AuthenticationType).ToArray());

            return Redirect("/");
        }
    }
}