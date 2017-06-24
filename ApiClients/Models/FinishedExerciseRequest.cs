using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.Models
{
    public class FinishedExerciseRequest
    {
        public DateTime After { get; set; }

        public DateTime Before { get; set; }
    }
}
