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
        public async Task<ServiceResult> Login(string login, string password)
        {
            var client = new ApiClients.AccountClient();
            var tokenResponse = await client.GetToken(login, password);
            if (tokenResponse.Success)
            {
                await UserStore.SaveUser(tokenResponse.Data.Id, login, tokenResponse.Data.Token, tokenResponse.Data.ValidTo);
            }
            return new ServiceResult { Success = tokenResponse.Success, Message = tokenResponse.Message };
        }

        public async Task<ServiceResult> Register(string login, string password)
        {
            var client = new ApiClients.AccountClient();
            var registerResponse = await client.Register(new ApiClients.Models.Account.RegisterRequest { Password = password, ConfirmPassword = password, Email = login }, Environment.NewLine);
            return new ServiceResult { Success = registerResponse.Success, Message = registerResponse.Message };
        }
    }
}
