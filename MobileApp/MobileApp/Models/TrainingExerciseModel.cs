using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Models
{
    public class TrainingExerciseModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int SeriesNumber { get; set; }

        public int Interval { get; set; }

        public int NextExerciseInterval { get; set; }

        public int SeriesTime { get; set; }

        public int CalloriesPerHour { get; set; }

        public string ImageName { get; set; }
    }
}
