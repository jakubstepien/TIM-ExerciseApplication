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
        [Obsolete("Constructor for xaml design")]
        public ExercisesList()
        {
            InitializeComponent();

        }

        public ExercisesList(Services.ITestService service)
        {
            InitializeComponent();
            this.BindingContext = new ViewModels.Exercises.ExerciseList();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var exercie = e.Item as ViewModels.Exercises.ExerciseListElement;
            if(exercie != null)
            {
                exercie.DetailsVisable = !exercie.DetailsVisable;
            }
        }
    }
}