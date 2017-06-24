using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.ViewModels.Statistics
{
    public class SummaryViewModel : BaseViewModel
    {
        public SummaryViewModel(IEnumerable<FinishedExcercise> excercises)
        {
            FinishedExcercises = new ObservableCollection<FinishedExcercise>(excercises);
        }

        private ObservableCollection<FinishedExcercise> finishedExcercises;

        public ObservableCollection<FinishedExcercise> FinishedExcercises
        {
            get { return finishedExcercises; }
            set { finishedExcercises = value; OnPropertyChanged(); }
        }

        private string excerciseTotal;
        public string ExcerciseTotal
        {
            get { return excerciseTotal; }
            set { excerciseTotal = value; OnPropertyChanged(); }
        }

        private string calloriesTotal;
        public string CalloriesTotal
        {
            get { return calloriesTotal; }
            set { calloriesTotal = value; OnPropertyChanged(); }
        }

    }
}
