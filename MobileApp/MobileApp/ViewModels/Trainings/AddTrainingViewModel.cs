using MobileApp.ViewModels.Exercises;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels.Trainings
{
    public class AddTrainingViewModel : BaseViewModel
    {
        public AddTrainingViewModel(IEnumerable<ExcerciseViewModel> excercises)
        {
            Excercises = new ObservableCollection<TrainingExerciseViewModel>();
            ExcercisesTypes = excercises.Select(s => new KeyValuePair<string, Guid>(s.Name, s.Id)).ToList();
            ExcerciseForm = new TrainingExerciseViewModel();
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private KeyValuePair<string, Guid> selectedExcerciseType;

        public KeyValuePair<string, Guid> SelectedExcerciseType
        {
            get { return selectedExcerciseType; }
            set { selectedExcerciseType = value; OnPropertyChanged(); }
        }


        private TrainingExerciseViewModel excerciseForm;
        public TrainingExerciseViewModel ExcerciseForm
        {
            get { return excerciseForm; }
            set { excerciseForm = value; OnPropertyChanged(); }
        }

        private ObservableCollection<TrainingExerciseViewModel> excercises;
        public ObservableCollection<TrainingExerciseViewModel> Excercises
        {
            get { return excercises; }
            set { excercises = value; OnPropertyChanged(); }
        }

        public List<KeyValuePair<string, Guid>> ExcercisesTypes { get; set; }

        public ICommand AddExcercise { get { return new Command(AddExcerciseToList); } }

        private void AddExcerciseToList(object obj)
        {
            if (!string.IsNullOrEmpty(SelectedExcerciseType.Key))
            {
                ExcerciseForm.IdExcercise = SelectedExcerciseType.Value;
                ExcerciseForm.Name = SelectedExcerciseType.Key;
                if (ExcerciseForm.IsOk())
                {
                    Excercises.Add(ExcerciseForm);
                    ExcerciseForm = new TrainingExerciseViewModel();
                }
            }
        }
    }
}
