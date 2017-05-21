using MobileApp.ViewModels.MasterDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services.MasterDetail
{
    public class MenuOptionsService : IMenuOptionsService
    {
        public MasterDetailMenuItem[] GetMenuOptions()
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
            return options;
        }
    }
}
