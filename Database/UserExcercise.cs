using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    [Table("UserExcercise")]
    public class UserExcercise
    {
        [Key]
        [Column(Order = 0)]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid IdExercise { get; set; }

        [ForeignKey("IdExercise")]
        public Exercise Exercise { get; set; }

        public bool IsFavourite { get; set; }
    }
}
