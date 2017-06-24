using MobileApp.Services.Excercise;
using MobileApp.ViewModels.Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.Exercises
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseStart : ContentPage
    {
        IExcerciseService service;
        ExcerciseViewModel exercise;

        public ExerciseStart()
        {
        }

        public ExerciseStart(IExcerciseService service, ExcerciseViewModel exercise)
        {
            this.service = service;
            this.exercise = exercise;
            this.Title = "Ćwiczenie: " + exercise.Name;
            InitializeComponent();
            name.Text = exercise.Name;
            image.Source = service.GetImageSource(exercise.Id, exercise.ImageName);
        }


        private void Started(object sender, EventArgs e)
        {
            startButton.IsEnabled = false;

            int seriesTime = 30;
            int interval = 20;
            var currentSeries = 1;
            var timeLeft = seriesTime;
            var allSeries = 4;
            bool exerciseBreak = false;

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                if (exerciseBreak)
                {
                    currentState.Text = "Przerwa, następna seria - " + (currentSeries + 1) + "/" + allSeries;
                }
                else
                {
                    currentState.Text = "Seria: " + currentSeries + "/" + allSeries;
                }
                currentTime.Text = timeLeft.ToString();
                timeLeft--;
                if (timeLeft == 0)
                {
                    if (!exerciseBreak)
                    {
                        timeLeft = interval;
                        if (currentSeries == allSeries)
                        {
                            currentState.Text = "Koniec ćwiczenia";
                            currentTime.Text = "0";
                            startButton.IsEnabled = true;
                            return false;
                        }
                    }
                    else
                    {
                        currentSeries++;
                        timeLeft = seriesTime;
                    }
                    exerciseBreak = !exerciseBreak;
                }
                return true;
            });



        }
    }
}