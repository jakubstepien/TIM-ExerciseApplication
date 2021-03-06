﻿using MobileApp.Services.Excercise;
using MobileApp.Services.Training;
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
    public partial class TrainingsList : ContentPage
    {
        ITrainingService trainingService;
        IExcerciseService excerciseService;
        Utills.IApp app;

        public TrainingsList()
        {
            InitializeComponent();
        }

        public TrainingsList(Utills.IApp app, ITrainingService trainingService, IExcerciseService excerciseService)
        {
            this.app = app;
            this.trainingService = trainingService;
            this.excerciseService = excerciseService;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            TrainingListViewModel viewModel = null;
            var trainingsResult = await trainingService.GetTrainingList();
            if (trainingsResult.Success)
            {
                await Task.Factory.StartNew(() =>
                {
                    viewModel = new TrainingListViewModel(trainingsResult.Result);
                });
            }
            else
            {
                viewModel = new TrainingListViewModel();
            }
            this.BindingContext = viewModel;
        }

        private async void DeleteTraining(object sender, EventArgs e)
        {
            var id = (sender as Button).CommandParameter;
            Guid trainingId;
            if (id != null && Guid.TryParse(id.ToString(), out trainingId))
            {
                var action = await DisplayAlert("Usunięcie treningu", "Czy napewno chcesz usunąć trening", "Tak", "Nie");
                if (action)
                {
                    var deleteResult = await trainingService.DeleteTraining(trainingId);
                    if (deleteResult.Success)
                    {
                        var viewModel = BindingContext as TrainingListViewModel;
                        await viewModel.RemoveById(trainingId);
                        await Utills.ToastHelper.ShowToast("Trening został ununięty.");
                    }
                    else
                    {
                        await Utills.ToastHelper.ShowToast("Nie udało się usunąć treningu.");
                    }
                }
            }
        }

        private async void StartTraining(object sender, EventArgs e)
        {
            var id = (sender as Button).CommandParameter;
            Guid trainingId;
            if (id != null && Guid.TryParse(id.ToString(), out trainingId))
            {
                var startPage = new TrainingStart(app, trainingService,excerciseService, trainingId);
                await Navigation.PushAsync(startPage);
            }
        }

        private async void AddNewTraining(object sender, EventArgs e)
        {

            var addTraingPage = new AddTraining(excerciseService, trainingService);
            await Navigation.PushAsync(addTraingPage);


        }
    }
}