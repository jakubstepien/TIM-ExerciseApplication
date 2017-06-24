using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Utills.TimeInput
{
    static class TimeInputHelper
    {
        public static List<char> ToSixChars(List<char> nums, char charToFill = '0')
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
