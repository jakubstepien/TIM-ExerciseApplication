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
    public partial class ExercisesList : ContentPage
    {
        IExcerciseService service;
        ExerciseList viewModel;

        [Obsolete("Constructor for xaml design")]
        public ExercisesList()
        {
            InitializeComponent();
        }

        public ExercisesList(IExcerciseService service, ExerciseList exerciseListViewModel)
        {
            this.service = service;
            viewModel = exerciseListViewModel;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            await UpdateExcercises();
        }

        private async Task UpdateExcercises()
        {
            var excercises = await service.GetExercisesViewModels();
            if (excercises.Success)
            {
                BindingContext = viewModel;
                viewModel.SetExcercises(excercises.Result);
            }
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var exercie = e.Item as ExerciseListElement;
            if (exercie != null)
            {
                exercie.DetailsVisable = !exercie.DetailsVisable;
            }
        }
    }
}