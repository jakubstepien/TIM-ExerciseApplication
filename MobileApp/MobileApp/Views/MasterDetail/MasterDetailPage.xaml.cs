﻿using MobileApp.ViewModels;
using MobileApp.ViewModels.MasterDetail;
using MobileApp.ViewModels.MasterDetail.MenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Autofac;

namespace MobileApp.Views.MasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage : Xamarin.Forms.MasterDetailPage
    {
        private readonly Autofac.ILifetimeScope lifetimeScope;

        [Obsolete("Constructor for xaml design")]
        public MasterDetailPage()
        {
        }

        public MasterDetailPage(ILifetimeScope lifetimeScope, Utills.IApp app, Services.Account.IAccountService accountService, MasterDetailPageMasterViewModel masterViewModel)
        {
            InitializeComponent();
            MasterPage.MasterDetailPage = this;
            this.lifetimeScope = lifetimeScope;
            MasterPage.App = app;
            MasterPage.accountService = accountService;
            MasterPage.BindingContext = masterViewModel;
        }

        public void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Type type = null;
            string title = string.Empty;
            if(e.SelectedItem is ViewModels.MasterDetail.MenuItem.BaseMenuItem)
            {
                var item = e.SelectedItem as ViewModels.MasterDetail.MenuItem.BaseMenuItem;
                if (item == null)
                    return;
                type = item.TargetType;
                title = item.Name;
                if (e.SelectedItem is MasterDetailMenuItem)
                {
                    RefreshList(item as MasterDetailMenuItem);
                }
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
            var page = (Page)lifetimeScope.Resolve(type);
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