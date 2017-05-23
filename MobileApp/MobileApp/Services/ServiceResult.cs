using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public class ServiceResult<T> : ServiceResult
    {
        public T Result { get; set; }
    }

    public class ServiceResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
