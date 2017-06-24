using MobileApp.Services.Excercise;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.ViewModels.Exercises
{
    public class ExerciseList : BaseViewModel
    {
        private ObservableCollection<ExerciseListElement> excercises = new ObservableCollection<ExerciseListElement>();
        public IExcerciseService ExcerciseService { get; set; }

        public ExerciseList(IExcerciseService excerciseService)
        {
            this.ExcerciseService = excerciseService;
        }

        public ObservableCollection<ExerciseListElement> Excercises
        {
            get { return excercises; }
            set { excercises = value; OnPropertyChanged(); }
        }
        
        public void SetExcercises(IEnumerable<ExerciseListElement> excercises)
        {
            foreach (var excercise in excercises)
            {
                excercise.Parent = this;
            }
            Excercises = new ObservableCollection<ExerciseListElement>(excercises);
        }

    }
}
