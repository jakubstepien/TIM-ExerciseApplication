using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MobileApp
{
    public partial class App : Application, Utills.IApp
    {
        IContainer container;

        public App()
        {
            InitializeComponent();
            var builder = new ContainerBuilder();
            builder.RegisterModule<Utills.Autofac.AppModule>();
            container = builder.Build();
            
            var login =  container.Resolve<Views.Account.Login>();
            login.App = this;
            MainPage = login;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public void HandleLoggingIn()
        {
            MainPage = container.Resolve<Views.MasterDetail.MasterDetailPage>();
        }
    }
}
