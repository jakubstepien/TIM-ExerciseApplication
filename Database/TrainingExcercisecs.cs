using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class TrainingExcercise
    {
        [Key]
        [Column(Order = 0)]
        public Guid IdExercise { get; set; }

        [ForeignKey("IdExercise")]
        public Exercise Excercise { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid IdTraining { get; set; }

        [ForeignKey("IdTraining")]
        public Training Training { get; set; }

        public int Series { get; set; }

        public int Interval { get; set; }

        public int TimeSpan { get; set; }
    }
}
