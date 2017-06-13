using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    [Table("Exercise")]
    public class Exercise
    {
        [Key]
        public Guid IdExercise { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Description { get; set; }

        public byte[] Image { get; set; }

        public int CaloriesPerHour { get; set; }

        public ICollection<UserExcercise> UserExcercise { get; set; }
    }
}
