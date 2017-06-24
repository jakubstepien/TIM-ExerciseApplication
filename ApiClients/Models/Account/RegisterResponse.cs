using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.Models.Account
{
    public class RegisterResponse
    {
        public ModelState ModelState { get; set; }

        public string Message { get; set; }
    }

    public class ModelState
    {
        string[] Errors { get; set; }
    }
}
