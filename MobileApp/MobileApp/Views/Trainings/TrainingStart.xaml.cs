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

        public TrainingStart()
        {
            InitializeComponent();
        }

        public TrainingStart(ITrainingService trainingService, string trainingName)
        {
            Title = trainingName;
            this.trainingService = trainingService;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            currentExerciseName.Text = "Pompki";
            status.Text = "2/5";
            series.Text = "Seria 1/2";
            timer.Text = "80";
            base.OnAppearing();
        }

        private void Start(object sender, EventArgs e)
        {

        }
    }
}