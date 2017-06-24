using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Utills
{
    static class TimeInputHelper
    {
        public static string GetTimeString(string oldTextValue, string newTextValue)
        {
            bool removedChar = !string.IsNullOrEmpty(oldTextValue) && oldTextValue.Contains("s") && !newTextValue.Contains("s");
            var nums = newTextValue.ToCharArray().Where(w => char.IsNumber(w)).ToList();
            if (removedChar)
            {
                nums.RemoveAt(nums.Count - 1);
            }
            nums = ToSixChars(nums);
            nums.Insert(2, 'h');
            nums.Insert(3, ' ');
            nums.Insert(6, 'm');
            nums.Insert(7, ' ');
            nums.Insert(10, 's');
            return string.Concat(nums);
        }

        private static List<char> ToSixChars(List<char> nums, char charToFill = '0')
        {
            if (nums.Count > 6)
            {
                nums = nums.Skip(nums.Count - 6).ToList();
            }
            else if (nums.Count < 6)
            {
                nums.InsertRange(0, Enumerable.Repeat(charToFill, 6 - nums.Count));
            }

            return nums;
        }

        public static int GetSecondsFromTimeString(this string time)
        {
            var nums = time.ToCharArray().Where(w => char.IsNumber(w)).ToList();
            ToSixChars(nums);

            var hourSeconds = int.Parse(string.Concat(nums[0], nums[1])) * 3600;
            var minSeconds = int.Parse(string.Concat(nums[2], nums[3])) * 60;
            var seconds = int.Parse(string.Concat(nums[4], nums[5]));

            return hourSeconds + minSeconds + seconds;
        }
    }
}
