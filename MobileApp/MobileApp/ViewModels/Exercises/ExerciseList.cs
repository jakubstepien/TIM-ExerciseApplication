using MobileApp.Services.Excercise;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.ViewModels.Exercises
{
    public class ExerciseList : BaseViewModel
    {
        private ObservableCollection<ExcerciseViewModel> excercises = new ObservableCollection<ExcerciseViewModel>();
        public IExcerciseService ExcerciseService { get; set; }
        INavigation navigation;

        public ExerciseList(INavigation navigation, IExcerciseService excerciseService)
        {
            this.navigation = navigation;
            this.ExcerciseService = excerciseService;
        }

        public ObservableCollection<ExcerciseViewModel> Excercises
        {
            get { return excercises; }
            set { excercises = value; OnPropertyChanged(); }
        }
        
        public void SetExcercises(IEnumerable<ExcerciseViewModel> excercises)
        {
            foreach (var excercise in excercises)
            {
                excercise.Parent = this;
            }
            Excercises = new ObservableCollection<ExcerciseViewModel>(excercises);
        }

        public async Task ExerciseSelected(ExcerciseViewModel exercise)
        {
            var view = new Views.Exercises.ExerciseStart(ExcerciseService, exercise);
            await navigation.PushAsync(view);
        }

    }
}
