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
            Text = "00h 00m 00s";
            Keyboard = Keyboard.Numeric;
        }

        private void FormatText(object sender, TextChangedEventArgs e)
        {
            this.Text = GetTimeString(e.OldTextValue, e.NewTextValue);
        }

        private string GetTimeString(string oldTextValue, string newTextValue)
        {
            if (!string.IsNullOrEmpty(newTextValue))
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
            return oldTextValue;
        }

        public int GetSeconds()
        {
            return Text.GetSecondsFromTimeString();
        }
    }
}
