using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.ViewModels.Statistics
{
    public class FinishedExcercise : BaseViewModel
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged(); }
        }

        private decimal callories;

        public decimal Callories
        {
            get { return callories; }
            set { callories = value; OnPropertyChanged(); }
        }

    }
}
