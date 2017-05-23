using MobileApp.Utills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services.Account
{
    public interface IAccountService
    {
        ServiceResult Login(string login, string password);

        ServiceResult Register(string login, string password);
    }
}
