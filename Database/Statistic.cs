using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Statistic
    {
        [Key]
        public Guid IdStatistic { get; set; }

        [Index]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(256)]
        public string ExerciseName { get; set; }

        public decimal Callories { get; set; }

        [ForeignKey("User")]
        public Guid IdUser { get; set; }

        public ApplicationUser User { get; set; }
    }
}
