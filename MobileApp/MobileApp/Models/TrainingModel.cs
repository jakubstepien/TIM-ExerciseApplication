﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Models
{
    public class TrainingModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public TrainingExerciseModel[] Exercises { get; set; }
    }
}
