﻿using System;
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
        }

        public ExercisesList(Services.ITestService service)
        {
            InitializeComponent();
        }

    }
}