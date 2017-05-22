using MobileApp.ViewModels;
using MobileApp.ViewModels.MasterDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.MasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage : Xamarin.Forms.MasterDetailPage
    {
        public MasterDetailPage()
        {
            InitializeComponent();
            MasterPage.MasterDetailPage = this;
        }

        public void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Type type = null;
            string title = string.Empty;
            if(e.SelectedItem is MasterDetailMenuItem)
            {
                var item = e.SelectedItem as MasterDetailMenuItem;
                if (item == null)
                    return;
                type = item.TargetType;
                title = item.Name;
                RefreshList(item);
            }
            else if(e.SelectedItem is MasterDetailMenuSubItem)
            {
                var item = e.SelectedItem as MasterDetailMenuSubItem;
                if (item == null)
                    return;
                type = item.TargetType;
                title = item.Name;
            }
            else
            {
                return;
            }
            if(type != null)
            {
                ChangeDetail(type, title);
            }

            MasterPage.MenuItems.SelectedItem = null;
        }

        public void ChangeDetail(Type type, string title)
        {
            var page = (Page)Activator.CreateInstance(type);
            page.Title = title;

            Detail = new NavigationPage(page);
            IsPresented = false;
        }

        private void RefreshList(MasterDetailMenuItem item)
        {
            var masterViewModel = MasterPage.BindingContext as MasterDetailPageMasterViewModel;
            try
            {

                MasterPage.MenuItems.BatchBegin();
                if (masterViewModel != null)
                {
                    foreach (var listItem in masterViewModel.MenuItems)
                    {
                        listItem.ShowSubItems = listItem.SubItems != null && listItem.SubItems.Length != 00 && listItem.Id == item.Id && !listItem.ShowSubItems;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            finally
            {
                MasterPage.MenuItems.BatchCommit();
            }
        }
    }
}