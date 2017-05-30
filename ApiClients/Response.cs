using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClients
{
    public class Response
    {
        public bool Succes { get; set; }

        public string Message { get; set; }
    }

    public class Response<T> : Response
    {
        public T Data { get; set; }
    }
}
