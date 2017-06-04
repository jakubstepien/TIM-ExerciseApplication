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

            UserStore.SaveUser(login, "token", DateTime.Now.AddMonths(2));
            return new ServiceResult { Success = true };
        }

        public ServiceResult Register(string login, string password)
        {
            //TODO
            return new ServiceResult { Success = true };
        }
    }
}
