using MobileApp.Services.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.Summary
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Summary : ContentPage
    {
        IStatisticsService service;

        public Summary()
        {
            InitializeComponent();
        }

        public Summary(IStatisticsService service)
        {
            Title = "Podsumowanie";
            this.service = service;
            InitializeComponent();
            before.Date = DateTime.Now.Date;
            after.Date = DateTime.Now.Date.AddDays(-7d);
        }

        private async void Search(object sender, EventArgs e)
        {
            var before = this.before.Date;
            var after = this.after.Date;
            if (before < after)
                return;
            var result = await service.GetBetweenDate(after, before);
            if (result.Success)
            {
                ViewModels.Statistics.SummaryViewModel viewModel = null;
                await Task.Factory.StartNew(() =>
                {
                    int total = 0;
                    decimal callories = 0m;
                    viewModel = new ViewModels.Statistics.SummaryViewModel(result.Result);
                    foreach (var excercise in result.Result)
                    {
                        callories += excercise.Callories;
                        total++;
                    }
                    viewModel.CalloriesTotal = "Spalonych zostało " + callories + " kalorii.";
                    viewModel.ExcerciseTotal = "Wykonanych zostało " + total + " ćwiczeń.";
                });
                this.BindingContext = viewModel;
            }
        }
    }
}