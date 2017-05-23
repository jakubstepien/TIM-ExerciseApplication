using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace MobileApp.Utills
{
    public static class UserStore
    {
        private const string appName = "TIM-ExerciseApp";
        private const string tokenKey = "token";
        private const string tokenEndDateKey = "tokenEndDateKey";

        public static void SaveUser(string login, string token, DateTime tokenEndDate)
        {
            var account = new Account { Username = login };
            account.Properties.Add(tokenKey, token);
            account.Properties.Add(tokenEndDateKey, tokenEndDate.ToString());

            AccountStore.Create().Save(account, appName);
        }

        public static bool IsLoggedIn()
        {
            var logged = false;
            Account account = GetAccount();
            if (account != null)
            {
                logged = IsTokenValid(account);
            }
            return logged;
        }

        private static Account GetAccount()
        {
            return AccountStore.Create().FindAccountsForService(appName).FirstOrDefault();
        }

        private static bool IsTokenValid(Account account)
        {
            var now = DateTime.UtcNow;
            DateTime tokenDate;
            if (DateTime.TryParse(account.Properties[tokenEndDateKey], out tokenDate))
            {
                return tokenDate > now;
            }

            return false;
        }

        public static string GetToken()
        {
            var account = GetAccount();
            if (IsTokenValid(account))
            {
                return account.Properties[tokenKey];
            }
            return null;
        }

        public static void Logout()
        {
            var account = GetAccount();
            AccountStore.Create().Delete(account, appName);
        }
    }
}
