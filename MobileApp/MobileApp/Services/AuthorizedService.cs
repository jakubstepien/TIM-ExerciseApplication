using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public abstract class AuthorizedService
    {
        protected readonly Guid userId;
        protected readonly string token;

        public AuthorizedService()
        {
            token = Utills.UserStore.GetToken();
            userId = Utills.UserStore.GetId().Value;
        }
    }
}
