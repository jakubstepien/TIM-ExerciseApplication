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

        public string ApiServer { get { return "http://192.168.1.8"; } }

        public DateTime LastSleepDate { get; set; }

        public App()
        {
            ApiClients.BaseClient.Init(ApiServer);
            InitializeComponent();
            var builder = new ContainerBuilder();
            builder.RegisterModule<Utills.Autofac.AppModule>();
            builder.RegisterInstance<Utills.IApp>(this);

            container = builder.Build();

            if (Utills.UserStore.IsLoggedIn())
            {
                HandleLoggedin();
            }
            else
            {
                HandleLoggedOut();
            }
        }

        #region IAppImplementation

        public void HandleLoggedin()
        {
            MainPage = container.Resolve<Views.MasterDetail.MasterDetailPage>();
        }

        public void HandleLoggedOut()
        {
            MainPage = new NavigationPage(container.Resolve<Views.Account.Login>());
        }

        #endregion

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            LastSleepDate = DateTime.Now;
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }
}
