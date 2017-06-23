using ApiClients;
using Database;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Register(RegisterBindingModel model)
        {
            if (TryValidateModel(model))
            {
                var client = new AccountClient();
                var result = await client.Register(new ApiClients.Models.Account.RegisterRequest { ConfirmPassword = model.ConfirmPassword, Email = model.Email, Password = model.Password });
                if (result.Success)
                {
                    var signedIn = await SignIn(model.Email, model.Password);
                    if (signedIn)
                    {
                        return Redirect("/");
                    }
                }
                else
                {
                    ViewBag.Errors = result.Message;
                }
                
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginBindingModel model, string returnUrl = "/")
        {
            if (TryValidateModel(model))
            {
                var identitiy = HttpContext.User;
                var token = await new AccountClient().GetToken(model.Email, model.Password);
                if (token.Success)
                {
                    await Login(model.Email, model.Password, token.Data);
                    return Redirect(returnUrl);
                }
            }
            ViewBag.Errors = "Nieprawidłowy login lub hasło";
            return View(model);
        }

        private async Task<bool> SignIn(string email, string password)
        {
            var identitiy = HttpContext.User;
            var token = await new AccountClient().GetToken(email, password);
            if (token.Success)
            {
                await Login(email, password, token.Data);
                return true;
            }
            return false;
        }

        private async Task Login(string email, string password, string token)
        {
            UserManager<ApplicationUser, Guid> userManager = new UserManager<ApplicationUser, Guid>(new Providers.GuidUserStore(new ApplicationDbContext()));

            var user = userManager.Find(email, password);

            var authManager = HttpContext.GetOwinContext().Authentication;
            var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
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