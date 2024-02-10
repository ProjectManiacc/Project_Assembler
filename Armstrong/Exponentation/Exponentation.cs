using System;

namespace ArmstrongGUI
{
    public class Exponentation
    {
        public static int Power(int[] digits, int exponent)
        {
            int sum = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                sum += (int)Math.Pow(digits[i], exponent);
            }
            return sum;
        }
    }
}
