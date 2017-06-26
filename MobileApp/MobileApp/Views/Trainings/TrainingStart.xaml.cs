using MobileApp.Models;
using MobileApp.Services.Excercise;
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
        IExcerciseService excerciseService;
        bool canGoBack;
        Guid trainingId;
        Utills.IApp app;
        TrainingModel training;


        public TrainingStart()
        {
            InitializeComponent();
        }

        public TrainingStart(Utills.IApp app, ITrainingService trainingService, IExcerciseService excerciseService, Guid id)
        {
            Title = "Trening";
            trainingId = id;
            this.app = app;
            this.trainingService = trainingService;
            this.excerciseService = excerciseService;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var result = await trainingService.GetTraining(trainingId);
            if (result.Success)
            {
                Title = result.Result.Name;
                training = result.Result;
                if (string.IsNullOrEmpty(currentExerciseName.Text))
                {
                    currentExerciseName.Text = training.Name;
                }
            }
            base.OnAppearing();
        }

        private async void Start(object sender, EventArgs e)
        {
            if (training == null)
            {
                return;
            }
            var slideCreator = new Utills.TrainingSlideCreator(excerciseService);
            var slides = await slideCreator.CreateSlides(training);
            ToggleExercising(true);
            int time = -1;
            int currentSlide = 0;
            var start = DateTime.Now;
            SetSlide(slides[currentSlide]);
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                if (app.LastSleepDate > start)
                {
                    currentExerciseName.Text = "Aplikacja została zatrzymana";
                    series.Text = "";
                    status.Text = "";
                    timer.Text = "";
                    ToggleExercising(false);
                    return false;
                }
                time++;
                if (HasToChangeSlide(time, currentSlide, slides))
                {
                    currentSlide++;
                    if (currentSlide == slides.Length)
                    {
                        currentExerciseName.Text = "Trening zakończony";
                        series.Text = "Zapisywanie wyników";
                        timer.Text = "";
                        Task.Factory.StartNew(async () =>
                        {
                            await trainingService.AddFinishedTraining(training);
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                series.Text = "Zapisano wynik.";
                            });
                        });
                        ToggleExercising(false);
                        return false;
                    }
                    SetSlide(slides[currentSlide]);
                }
                var curTime = slides[currentSlide].Time - time;
                timer.Text = curTime == 0 ? "" : curTime.ToString();
                return true;
            });
        }

        private bool HasToChangeSlide(int time, int currentSlide, Slide[] slides)
        {
            return time >= slides[currentSlide].Time;
        }

        private void SetSlide(Slide slide)
        {
            status.Text = slide.Status;
            currentExerciseName.Text = slide.CurrentExerciseName;
            if (image.Source == null || (image.Source as UriImageSource).Uri.AbsoluteUri != slide.Image)
            {
                image.Source = slide.Image;
            }
            series.Text = slide.Series;
        }

        private void ToggleExercising(bool val)
        {
            startButton.IsVisible = !val;
            canGoBack = !val;
            NavigationPage.SetHasBackButton(this, !val);
        }

        protected override bool OnBackButtonPressed()
        {
            //false powoduje że nie można wrócić
            return !canGoBack;
        }
    }
}