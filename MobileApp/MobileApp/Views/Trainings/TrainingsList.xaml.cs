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
        public TrainingsList()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            TrainingListViewModel viewModel = null;
            await Task.Factory.StartNew(() =>
            {
                viewModel = new TrainingListViewModel(Enumerable.Range(0, 10).Select(s => new TrainingListItemViewModel { Id = Guid.NewGuid(), Name = s.ToString() }));
            });
            this.BindingContext = viewModel;
        }

        private async void DeleteTraining(object sender, EventArgs e)
        {
            var id = (sender as Button).CommandParameter;
            Guid trainingId;
            if (id != null && Guid.TryParse(id.ToString(), out trainingId))
            {
                var action = await DisplayAlert("Usunięcie treningu","Czy napewno chcesz usunąć trening", "Tak", "Nie");
                if (action)
                {
                    var viewModel = BindingContext as TrainingListViewModel;
                    await viewModel.RemoveById(trainingId);
                }
            }
        }
    }
}