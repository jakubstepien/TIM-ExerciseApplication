using Plugin.Toasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.Utills
{
    static class ToastHelper
    {
        public static async Task<INotificationResult> ShowToast(string message)
        {
            var notificator = DependencyService.Get<IToastNotificator>();
            var androidOptions = new AndroidOptions();
            androidOptions.DismissText = "Zamknij";
            var options = new NotificationOptions()
            {
                Description = message,
                //IsClickable = false,
                AndroidOptions = androidOptions
            };
            return await notificator.Notify(options);
        }

    }
}
