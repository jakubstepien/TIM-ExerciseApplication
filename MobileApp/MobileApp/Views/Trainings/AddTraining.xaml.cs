using MobileApp.Services.Excercise;
using MobileApp.ViewModels.Trainings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.Trainings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTraining : ContentPage
    {
        IExcerciseService excerciseService;


        public AddTraining()
        {
            InitializeComponent();
        }

        public AddTraining(IExcerciseService excerciseService)
        {
            this.excerciseService = excerciseService;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var result = await excerciseService.GetExercisesViewModels();
            if (result.Success)
            {
                this.BindingContext = new AddTrainingViewModel(result.Result);
            }
        }
    }
}