using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.Model.DTO
{
    public class TrainingDTO
    {
        public Guid IdTraining { get; set; }

        public string Name { get; set; }

        public Guid IdUser { get; set; }

        public IList<TrainingExcerciseDTO> Excercises { get; set; }
    }
}
