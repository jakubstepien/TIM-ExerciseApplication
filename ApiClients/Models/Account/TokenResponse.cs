using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients.Models.Account
{
    public class TokenResponse
    {
        public string Token { get; set; }

        public Guid Id { get; set; }

        public DateTime ValidTo { get; set; }
    }
}
