using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers.WebSite
{
    public static class ControllerHelper
    {
        public static string TokenClaimType => "api_token";

        public static string GetToken(this Controller controller)
        {
            var identitiy = controller.HttpContext.User?.Identity as ClaimsIdentity;
            if(identitiy != null)
            {
                var claim = identitiy.Claims.SingleOrDefault(s => s.Type == TokenClaimType);
                if(claim != null)
                {
                    return claim.Value;
                }
            }
            return null;
        }

    }
}