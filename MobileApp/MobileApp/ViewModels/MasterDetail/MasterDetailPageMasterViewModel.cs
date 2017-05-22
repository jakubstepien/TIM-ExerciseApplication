using MobileApp.ViewModels.MasterDetail.MenuItem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.ViewModels.MasterDetail
{
    public class MasterDetailPageMasterViewModel : BaseViewModel
    {
        public ObservableCollection<MasterDetailMenuItem> MenuItems { get; set; }

        public MasterDetailPageMasterViewModel()
        {
            var options = new[]
            {
                new MasterDetailMenuItem {Name = "Moje treningi", SubItems = new MasterDetailMenuSubItem[]
                {
                    new MasterDetailMenuSubItem { Name = "Dodaj trening", TargetType = typeof(Views.Trainings.AddTraining) },
                    new MasterDetailMenuSubItem { Name = "Lista treningów", TargetType = typeof(Views.Trainings.TrainingsList) } }
                },
                new MasterDetailMenuItem {Name = "Lista ćwiczeń", TargetType = typeof(Views.Exercises.ExercisesList)},
                new MasterDetailMenuItem {Name = "Podsumowanie", TargetType = typeof(Views.Summary.Summary)}
            };
            MenuItems = new ObservableCollection<MasterDetailMenuItem>(options);
        }
    }
}
