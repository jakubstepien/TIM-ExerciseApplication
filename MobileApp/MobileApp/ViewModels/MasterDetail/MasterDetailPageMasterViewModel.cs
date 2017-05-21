using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.ViewModels.MasterDetail
{
    public class MasterDetailPageMasterViewModel : BaseViewModel
    {
        public ObservableCollection<MasterDetailMenuItem> MenuItems { get; set; }

        public MasterDetailPageMasterViewModel()
        {
            var options = new Services.MasterDetail.MenuOptionsService().GetMenuOptions();
            MenuItems = new ObservableCollection<MasterDetailMenuItem>(options);
        }
    }
}
