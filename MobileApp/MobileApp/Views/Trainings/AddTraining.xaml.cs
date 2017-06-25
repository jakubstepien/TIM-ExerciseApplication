using MobileApp.Services.Excercise;
using MobileApp.Services.Training;
using MobileApp.ViewModels.Trainings;
using Plugin.Toasts;
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
        ITrainingService trainingService;

        public AddTraining()
        {
            InitializeComponent();
        }

        public AddTraining(IExcerciseService excerciseService, ITrainingService trainingService)
        {
            this.excerciseService = excerciseService;
            this.trainingService = trainingService;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var result = await excerciseService.GetExercisesViewModels();
            if (result.Success)
            {
                AddTrainingViewModel viewmodel = null;
                await Task.Factory.StartNew(() => {
                    viewmodel = new AddTrainingViewModel(result.Result);
                });
                this.BindingContext = viewmodel;
            }
        }

        private async void SaveTraining(object sender, EventArgs e)
        {
            var viewModel = BindingContext as AddTrainingViewModel;
            if(viewModel != null && !string.IsNullOrEmpty(viewModel.Name))
            {
                var result = await trainingService.AddTraining(viewModel);
                var notificator = DependencyService.Get<IToastNotificator>();

                var options = new NotificationOptions()
                {
                    Title = "TIM-ExcerciseApp",
                    Description = result.Success ? "Trening został dodany." : "Nie udało się dodać treningu"
                };

                var toast = await notificator.Notify(options);
            }
        }
    }
}