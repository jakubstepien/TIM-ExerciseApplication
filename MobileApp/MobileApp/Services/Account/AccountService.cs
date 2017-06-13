using MobileApp.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services.Account
{
    public class AccountService : IAccountService
    {
        public ServiceResult Login(string login, string password)
        {
            //TODO wysłać posta do web api
            var client = new ApiClients.AccountClient();
            var tokenResponse = client.GetToken(login, password);
            if (tokenResponse.Success)
            {
                UserStore.SaveUser(login, tokenResponse.Data, DateTime.Now.AddMonths(2));
            }
            return new ServiceResult { Success = true };
        }

        public ServiceResult Register(string login, string password)
        {
            //TODO
            return new ServiceResult { Success = true };
        }
    }
}
