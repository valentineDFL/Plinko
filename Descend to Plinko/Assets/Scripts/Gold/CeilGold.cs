using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Gold
{
    internal class CeilGold
    {
        public string Ceil(long count)
        {
            int thousend = 1000;
            int million = 1000000;
            int billion = 1000000000;
            string res = "";

            int[] nums = new int[] { thousend, million, billion };
            char[] chars = new[] { 'K', 'M', 'B' };

            if (count < nums[0])
            {
                res = count.ToString();
                return res;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (count >= nums[i])
                {
                    res = $"{Math.Round((double)count / nums[i], 3)}{chars[i]}";
                    continue;
                }
            }
            return res;
        }
    }
}
