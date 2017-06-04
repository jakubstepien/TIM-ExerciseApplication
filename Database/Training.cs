using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    [Table("Training")]
    public class Training
    {
        [Key]
        public Guid IdTraining { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [ForeignKey("User")]
        public Guid IdUser { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<TrainingExcercise> Excercises { get; set; } = new HashSet<TrainingExcercise>();
    }
}
