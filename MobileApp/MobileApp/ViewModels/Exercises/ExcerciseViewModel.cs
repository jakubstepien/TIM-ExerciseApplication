using MobileApp.Services.Excercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels.Exercises
{
    public class ExcerciseViewModel : BaseViewModel
    {
        const string NotFavouriedIcon = "ic_favorite_border_black_24dp.png";
        const string FavouriedIcon = "ic_favorite_black_24dp.png";

        public ExcerciseViewModel()
        {
            FavouriteCommand = new Command(SetFavourite);
            ExpandCommand = new Command(() => { DetailsVisable = !DetailsVisable; });
            SelectCommand = new Command(StartExcercise);
        }

        public ExerciseList Parent { get; set; }


        public Guid Id { get; set; } = Guid.NewGuid();
        public string ImageName { get; set; }
        public int CaloriesPerHour { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(); }
        }


        private bool favouriteIcon;
        public string FavouriteIcon
        {
            get { return favouriteIcon ? FavouriedIcon : NotFavouriedIcon; }
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



        private async void SetFavourite()
        {
            var result = await Parent.ExcerciseService.SetAsFavourite(Id);
            if (result.Success)
            {
                favouriteIcon = result.Result;
                OnPropertyChanged("FavouriteIcon");
            }
        }

        private async void StartExcercise()
        {
            await Parent.ExerciseSelected(this);
        }
    }
}
