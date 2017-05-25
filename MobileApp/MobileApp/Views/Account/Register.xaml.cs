using MobileApp.Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileApp.Utills;

namespace MobileApp.Views.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        readonly IAccountService accountService;

        readonly Utills.IApp app;

        [Obsolete]
        public Register()
        {
        }

        public Register(IAccountService accountService, IApp app)
        {
            this.accountService = accountService;
            this.app = app;
            InitializeComponent();
        }

        private void RegisterClick(object sender, EventArgs e)
        {
            if (!CanRegister())
            {
                return;
            }

            var registerResult = accountService.Register(login.Text, password.Text);
            if (registerResult.Success)
            {
                app.HandleLoggedin();
            }
            else
            {
                //TODO
            }
        }

        private bool CanRegister()
        {
            if (string.IsNullOrWhiteSpace(login.Text) || string.IsNullOrWhiteSpace(password.Text) || string.IsNullOrWhiteSpace(passwordCompare.Text))
            {
                SetError("Wypełnij wszystkie pola.");
                return false;
            }
            if (password.Text != passwordCompare.Text)
            {
                SetError("Hasła nie są jednakowe.");
                return false;
            }
            return true;
        }

        private void SetError(string msg)
        {
            errorMsgPanel.IsVisible = true;
            error.Text = msg;
        }
    }
}