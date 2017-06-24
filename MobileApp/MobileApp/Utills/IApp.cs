using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Utills
{
    public interface IApp
    {
        void HandleLoggedin();

        void HandleLoggedOut();

        string ApiServer { get;}

        DateTime LastSleepDate { get; }
    }
}
