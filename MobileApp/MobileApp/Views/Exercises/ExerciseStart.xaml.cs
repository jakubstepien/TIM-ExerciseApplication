using MobileApp.Services.Excercise;
using MobileApp.ViewModels.Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileApp.Utills;
using MobileApp.Utills.TimeInput;

namespace MobileApp.Views.Exercises
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseStart : ContentPage
    {
        IExcerciseService service;
        ExcerciseViewModel exercise;
        IApp app;
        bool canGoBack = true;

        public ExerciseStart()
        {
        }

        public ExerciseStart(IExcerciseService service, ExcerciseViewModel exercise, IApp app)
        {
            this.service = service;
            this.exercise = exercise;
            this.app = app;
            this.Title = "Ćwiczenie: " + exercise.Name;
            InitializeComponent();
            name.Text = exercise.Name;
            image.Source = service.GetImageSource(exercise.Id, exercise.ImageName);
            var emptytime = "00h 00m 00s";
            seriesSpan.Text = emptytime;
            interval.Text = emptytime;
        }

        protected override bool OnBackButtonPressed()
        {
            //false powoduje że nie można wrócić
            return !canGoBack;
        }


        private void Started(object sender, EventArgs e)
        {
            int allSeries;
            if (int.TryParse(series.Text, out allSeries))
            {
                ToggleExercising(true);

                int currentSeries = 1;
                int seriesTime = this.seriesSpan.Text.GetSecondsFromTimeString();
                int interval = this.interval.Text.GetSecondsFromTimeString();

                if (seriesTime == 00)
                {
                    ToggleExercising(false);
                    return;
                }

                var timeLeft = seriesTime;
                bool exerciseBreak = false;
                DateTime start = DateTime.Now;
                Device.StartTimer(new TimeSpan(0, 0, 1), () =>
                {
                    if (app.LastSleepDate > start)
                    {
                        currentState.Text = "Aplikacja została zatrzymana";
                        currentTime.Text = "";
                        ToggleExercising(false);
                        return false;
                    }
                    if (exerciseBreak)
                    {
                        currentState.Text = "Przerwa, następna seria - " + (currentSeries + 1) + "/" + allSeries;
                    }
                    else
                    {
                        currentState.Text = "Seria: " + currentSeries + "/" + allSeries;
                    }
                    if (timeLeft <= 0)
                    {
                        if (currentSeries == allSeries)
                        {
                            currentState.Text = "Koniec ćwiczenia, zpisywanie zmian.";
                            currentTime.Text = "";
                            Task.Factory.StartNew(async () =>
                            {
                                var saveResult = await service.SavedFinishedExercise(exercise.Name, CalculateTotalCallories(allSeries, seriesTime));
                                Device.BeginInvokeOnMainThread(() =>
                                {
                                    if (saveResult.Success)
                                    {
                                        currentState.Text = "Wykonane ćwiczenie zostało zapisane.";
                                    }
                                });
                            });
                            ToggleExercising(false);
                            return false;
                        }
                        if (!exerciseBreak && interval != 0)
                        {
                            timeLeft = interval;
                        }
                        else
                        {
                            currentSeries++;
                            timeLeft = seriesTime;
                        }
                        if (interval != 0)
                        {
                            exerciseBreak = !exerciseBreak;
                        }
                    }
                    currentTime.Text = timeLeft.ToString();
                    timeLeft--;
                    return true;
                });
            }
        }

        private decimal CalculateTotalCallories(int series, int seriesSeconds)
        {
            var totalSeconds = (decimal) series * seriesSeconds;
            return exercise.CaloriesPerHour * totalSeconds / 3600m;
        }

        private void ToggleExercising(bool val)
        {
            startButton.IsEnabled = !val;
            canGoBack = !val;
            NavigationPage.SetHasBackButton(this, !val);
        }
    }
}