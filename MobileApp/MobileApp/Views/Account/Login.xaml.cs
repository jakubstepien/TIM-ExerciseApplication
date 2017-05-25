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

        readonly Utills.IApp app;

        [Obsolete("Constructor for xaml design")]
        public Login()
        {
        }


        public Login(IAccountService accountService, Utills.IApp app)
        {
            this.accountService = accountService;
            this.app = app;
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
                app.HandleLoggedin();
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