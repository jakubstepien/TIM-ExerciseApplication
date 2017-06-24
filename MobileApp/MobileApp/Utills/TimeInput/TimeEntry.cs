using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.Utills.TimeInput
{
    public class TimeEntry : Entry
    {
        public TimeEntry()
        {
            TextChanged += FormatText;
        }

        private void FormatText(object sender, TextChangedEventArgs e)
        {
            this.Text = GetTimeString(e.OldTextValue, e.NewTextValue);
        }

        public static string GetTimeString(string oldTextValue, string newTextValue)
        {
            bool removedChar = !string.IsNullOrEmpty(oldTextValue) && oldTextValue.Contains("s") && !newTextValue.Contains("s");
            var nums = newTextValue.ToCharArray().Where(w => char.IsNumber(w)).ToList();
            if (removedChar)
            {
                nums.RemoveAt(nums.Count - 1);
            }
            nums = TimeInputHelper.ToSixChars(nums);
            nums.Insert(2, 'h');
            nums.Insert(3, ' ');
            nums.Insert(6, 'm');
            nums.Insert(7, ' ');
            nums.Insert(10, 's');
            return string.Concat(nums);
        }
    }
}
