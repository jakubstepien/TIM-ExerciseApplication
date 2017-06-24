using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.Models.DTO
{
    public class FinishedExerciseDTO
    {
        public string Name { get; set; }

        public decimal Callories { get; set; }

        public Guid UserId { get; set; }

        public DateTime Date { get; set; }
    }
}
