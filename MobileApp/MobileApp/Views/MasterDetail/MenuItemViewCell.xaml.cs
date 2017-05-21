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
    public partial class MenuItemViewCell : ViewCell
    {
        public event EventHandler<SelectedItemChangedEventArgs> SubMenuListSelected;

        public MenuItemViewCell()
        {
            InitializeComponent();
            SubItemsList.ItemSelected += SubItemsList_ItemSelected;
            BindingContextChanged += ViewCell_BindingContextChanged;
        }

        private void SubItemsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                SubMenuListSelected?.Invoke(this, e);
                SubItemsList.SelectedItem = null;
            }
        }

        private void ViewCell_BindingContextChanged(object sender, EventArgs e)
        {
            var context = BindingContext as MasterDetailMenuItem;
            if (context?.SubItems != null && context.SubItems.Length != 0)
            {
                this.SubItemsList.HeightRequest = context.SubItems.Length * context.SubItems[0].Height;
            }
        }
    }
}