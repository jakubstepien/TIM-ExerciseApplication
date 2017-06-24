using MobileApp.ViewModels;
using MobileApp.ViewModels.MasterDetail;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileApp.Utills;

namespace MobileApp.Views.MasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageMaster : ContentPage
    {
        public MasterDetailPage MasterDetailPage { get; set; }

        public ListView MenuItems { get; private set; }

        public IApp App { get; set; }

        public Services.Account.IAccountService accountService { get; set; }

        public MasterDetailPageMaster()
        {
            InitializeComponent();
            MenuItems = MenuItemsListView;
        }

        public void SelectedMenu(object sender, SelectedItemChangedEventArgs e)
        {
            MasterDetailPage.ItemSelected(sender, e);
        }

        private async void LogoutClick(object sender, EventArgs e)
        {
            await UserStore.Logout();
            App.HandleLoggedOut();
        }
    }
}