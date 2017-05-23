using MobileApp.Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        readonly IAccountService accountService;

        public Utills.IApp App { get; set; }

        [Obsolete("Constructor for xaml design")]
        public Login()
        {
        }


        public Login(IAccountService accountService)
        {
            this.accountService = accountService;
            InitializeComponent();
        }

        private void loginClick(object sender, EventArgs e)
        {
            var email = login.Text;
            var password = this.password.Text;
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                errorMsg.IsVisible = true;
                return;
            }
            var result = accountService.Login(email, password);
            if (result.Success)
            {
                errorMsg.IsVisible = false;
                App.HandleLoggingIn();
            }
            else
            {
                //TODO
            }
        }

        private void registerClick(object sender, EventArgs e)
        {

        }
    }
}