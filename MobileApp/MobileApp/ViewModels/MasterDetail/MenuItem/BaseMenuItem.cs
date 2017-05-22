using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.ViewModels.MasterDetail.MenuItem
{
    public abstract class BaseMenuItem : BaseViewModel
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Name { get; set; }

        public Type TargetType { get; set; }
    }
}
