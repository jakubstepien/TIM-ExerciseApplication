﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.Models.DTO
{
    public class TrainingExcerciseDTO
    {
        public Guid Id { get; set; }

        public Guid IdExcercise { get; set; }

        public int Series { get; set; }

        public int Interval { get; set; }

        public int TimeSpan { get; set; }

        public int IntervalBeforeNextExercise { get; set; }

        public int? CalloriesPerHour { get; set; }

        public string ImageName { get; set; }

        public string Name { get; set; }
    }
}

