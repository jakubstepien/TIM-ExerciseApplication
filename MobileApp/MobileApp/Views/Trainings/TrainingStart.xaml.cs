using MobileApp.Services.Training;
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
    public partial class TrainingStart : ContentPage
    {
        ITrainingService trainingService;
        Guid trainingId;
        public TrainingStart()
        {
            InitializeComponent();
        }

        public TrainingStart(ITrainingService trainingService, Guid id)
        {
            Title = "Trening";
            trainingId = id;
            this.trainingService = trainingService;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var result = await trainingService.GetTraining(trainingId);
            base.OnAppearing();
        }

        private void Start(object sender, EventArgs e)
        {

        }
    }
}