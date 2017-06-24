using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels.Exercises
{
    public class ExerciseListElement : BaseViewModel
    {

        public ExerciseListElement()
        {
            FavouriteCommand = new Command(SetFavourite);
            ExpandCommand = new Command(() => { DetailsVisable = !DetailsVisable; });
            SelectCommand = new Command(() => { });
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private bool detailsVisable;

        public bool DetailsVisable
        {
            get { return detailsVisable; }
            set { detailsVisable = value; OnPropertyChanged(); }
        }

        public ICommand FavouriteCommand { get; private set; }
        public ICommand ExpandCommand { get; private set; }
        public ICommand SelectCommand { get; private set; }



        private void SetFavourite()
        {
        }

    }
}
