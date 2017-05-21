using MobileApp.ViewModels.MasterDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services.MasterDetail
{
    interface IMenuOptionsService
    {
        MasterDetailMenuItem[] GetMenuOptions();
    }
}
