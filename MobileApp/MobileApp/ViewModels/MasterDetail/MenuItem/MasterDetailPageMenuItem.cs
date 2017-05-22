using MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.ViewModels.MasterDetail.MenuItem
{

    public class MasterDetailMenuItem : BaseMenuItem
    {
        public string Image { get; set; }

        private bool _showSubItems = false;
        public bool ShowSubItems { get { return _showSubItems; } set { _showSubItems = value; OnPropertyChanged(); } }

        public MasterDetailMenuSubItem[] SubItems { get; set; }
    }
}