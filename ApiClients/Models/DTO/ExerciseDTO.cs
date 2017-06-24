using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.Model.DTO
{
    public class ExerciseDTO
    {
        public Guid IdExercise { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public string ImageName { get; set; }

        public int CaloriesPerHour { get; set; }
    }
}
