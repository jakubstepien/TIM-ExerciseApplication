using Autofac;
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

        readonly ILifetimeScope lifetimeScope;

        [Obsolete("Constructor for xaml design")]
        public Login()
        {
        }


        public Login(ILifetimeScope lifetimeScope, IAccountService accountService, Utills.IApp app)
        {
            this.accountService = accountService;
            this.app = app;
            this.lifetimeScope = lifetimeScope;
            InitializeComponent();
        }

        private async void LoginClick(object sender, EventArgs e)
        {
            var email = login.Text;
            var password = this.password.Text;
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                errorMsg.IsVisible = true;
                return;
            }
            var result = await accountService.Login(email, password);
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

        private void RegisterClick(object sender, EventArgs e)
        {
            var registerView = lifetimeScope.Resolve<Register>();
            Navigation.PushAsync(registerView);
        }
    }
}