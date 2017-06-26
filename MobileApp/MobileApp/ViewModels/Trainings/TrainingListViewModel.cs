using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.ViewModels.Trainings
{
    public class TrainingListViewModel : BaseViewModel
    {
        public TrainingListViewModel(IEnumerable<TrainingListItemViewModel> trainings)
        {
            Trainings = new ObservableCollection<TrainingListItemViewModel>(trainings);
        }

        public TrainingListViewModel()
        {

        }

        private ObservableCollection<TrainingListItemViewModel> trainings;

        public ObservableCollection<TrainingListItemViewModel> Trainings
        {
            get { return trainings; }
            set { trainings = value; OnPropertyChanged(); }
        }

        public async Task RemoveById(Guid id)
        {
            int index = -1;
            await Task.Factory.StartNew(() => {
                try
                {
                    index = Trainings.Select((s, i) => new { Index =  i, Value = s }).Where(w => w.Value.Id == id).First().Index;
                }
                catch(Exception e) { }
            });
            if(index != -1)
            {
                Trainings.RemoveAt(index);
            }
        }
    }

    public class TrainingListItemViewModel : BaseViewModel
    {
        private Guid id;
        public Guid Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }


        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

    }
}

