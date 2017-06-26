using ApiClients.Models;
using ApiClients.Models.Account;
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
            Response<TokenResponse> tokenResponse = await GetAndStoreToken(login, password, client);
            return new ServiceResult { Success = tokenResponse.Success, Message = tokenResponse.Message };
        }

        private static async Task<Response<TokenResponse>> GetAndStoreToken(string login, string password, ApiClients.AccountClient client)
        {
            var tokenResponse = await client.GetToken(login, password);
            if (tokenResponse.Success)
            {
                await UserStore.SaveUser(tokenResponse.Data.Id, login, tokenResponse.Data.Token, tokenResponse.Data.ValidTo);
            }

            return tokenResponse;
        }

        public async Task<ServiceResult> Register(string login, string password)
        {
            var client = new ApiClients.AccountClient();
            var registerResponse = await client.Register(new RegisterRequest { Password = password, ConfirmPassword = password, Email = login }, Environment.NewLine);
            if (registerResponse.Success)
            {
                var tokenResponse = await GetAndStoreToken(login, password, client);
                return new ServiceResult { Success = tokenResponse.Success, Message = tokenResponse.Message };
            }
            return new ServiceResult { Success = registerResponse.Success, Message = registerResponse.Message };
        }
    }
}
