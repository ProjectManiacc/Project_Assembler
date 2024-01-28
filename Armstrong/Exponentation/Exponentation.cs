using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exponentation
{
    public class Exponentation
    {
        public int power(int[] digits, int exponent)
        {
            int sum = 0;
            for (int i = 0; i< digits.Length; i++)
            {
                sum += (int)Math.Pow(digits[i], exponent);
            }


            return sum;
        }
    }
}
