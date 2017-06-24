using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.ViewModels.Exercises
{
    public class ExerciseList : BaseViewModel
    {
        private ObservableCollection<ExerciseListElement> excercises = new ObservableCollection<ExerciseListElement>();

        public ObservableCollection<ExerciseListElement> Excercises
        {
            get { return excercises; }
            set { excercises = value; OnPropertyChanged(); }
        }


        public ExerciseList()
        {
            excercises = new ObservableCollection<ExerciseListElement>(new ExerciseListElement[] {
                new ExerciseListElement {Name = "Pierwzsy", DetailsVisable = false,  },
                new ExerciseListElement {Name = "Drugi", DetailsVisable = false,  },
                new ExerciseListElement {Name = "Trzeci", DetailsVisable = false,  },
                new ExerciseListElement {Name = "Czwarty", DetailsVisable = false,  },
                new ExerciseListElement {Name = "Piaty", DetailsVisable = false,  },
            });
        }

    }
}
