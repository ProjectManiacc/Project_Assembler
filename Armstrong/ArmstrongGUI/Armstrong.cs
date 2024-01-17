

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ArmstrongGUI
{
    class Armstrong
    {
        [DllImport(@"C:\Users\piotrek\Desktop\Project_Assembler\Armstrong\x64\Debug\Assembler.dll")]
        public static extern void asm_power(short[] vector, int exponent, out short result1, out short result2, out short result3, out short result4);
        [DllImport(@"C:\Users\piotrek\Desktop\Project_Assembler\Armstrong\x64\Debug\Assembler6.dll")]
        public static extern void asm_power6(int[] vector, int exponent, out int result1, out int result2);
        public string Result { get; private set; }


        int Power(int x, int y)
        {
            // We don't want to import a whole math library for just integer power.
            int result = 1;
            for (int i = 0; i < y; ++i)
            {
                result *= x;
            }
            return result;
        }

        List<int> SplitNumber(int number)
        {
            List<int> result = new List<int>();
            while (number >= 1)
            {
                result.Add((int)(number - 10 * (number / 10)));
                number /= 10;
            }
            return result;
        }

        /* Let's consider this: c# is compiled to code, which uses 4B ints even,
        when counting from 0 to 4. Using 2B numbers for exponents resulting in 2B
        (or smaller) numbers should accellerate execution a bit.
        Maximum calculated number for each digit is 9^exponent. So:
        Exponent          bytes used by (9^Exponent)
            5               2
            6               3 (4)
            7               3 (4)
            8               4
            9               4
            10              4
            11              5 (8)
        This means we better have 2 methods depending on exponent to better utilize CPU's
        capabilities.
        */
        int CountArmstrongSum(List<int> numbers, int exponent)
        {
            if (exponent < 2 || exponent > 10) return 0; //instead of throwing
            if (exponent < 6) return CountArmstrongSum2To5(numbers, exponent);
            return CountArmstrongSum6To10(numbers, exponent);                
        }

        int CountArmstrongSum2To5(List<int> numbers, int exponent)
        {
            Digits2B vectors = new Digits2B(numbers);
            Digits2B result = new Digits2B();
            for (int i = 0; i < vectors.CountOfFours; ++i)
            {
                short r1, r2, r3, r4;
                asm_power(vectors.Fours[i], exponent, out r1, out r2, out r3, out r4);
                short[] ret = {r1, r2, r3, r4};
                result.Add(ret);
            }
            return result.Sum();
        }
        int CountArmstrongSum6To10(List<int> numbers, int exponent) {
            Digits4B vectors = new Digits4B(numbers);
            Digits4B result = new Digits4B();
            for (int i = 0; i < vectors.CountOfTwos; ++i)
            {
                int i1, i2;
                asm_power6(vectors, int exponent, out i1, out i2);
                int[] ret = {i1, i2};
                result.Add(ret);
            }
            return result.Sum();
        }

         void PrintArmstrongTestResultMessage(bool succeeded, int number, int exponent)
        {
           
            List<int> digits = SplitNumber(number);
            if (succeeded)
            {

                StringBuilder resultBuilder = new StringBuilder();

                foreach (var i in digits)
                {
                    resultBuilder.Append($"{i}^{exponent} + ");
                }
                //Console.CursorLeft -= 2;
                resultBuilder.Remove(resultBuilder.Length - 2, 2); // Remove the trailing " + "
                resultBuilder.Append($"= {number}");
                resultBuilder.AppendLine();
                resultBuilder.Append($"This is Armstrong's number for the power of {exponent}.");
                resultBuilder.AppendLine();
                Result += resultBuilder.ToString();
            }
           
        }

        public void ArmstrongTest(int number)
        {
            List<int> digits = SplitNumber(number);
            int exponent = digits.Count;
            int sum = CountArmstrongSum(digits, exponent);
            PrintArmstrongTestResultMessage(sum == number, number, exponent);
        }

        public void ArmstrongTest(int number, int exponent)
        {
            List<int> digits = SplitNumber(number);
            int sum = CountArmstrongSum(digits, exponent);
            PrintArmstrongTestResultMessage(sum == number, number, exponent);
        }

        public void ArmstrongRange(int numMin, int numMax, int exponentMin, int exponentMax)
        {
            //Result = "";
            for (int r = exponentMin; r <= exponentMax; ++r)
            {
                for (int n = numMin; n <= numMax; ++n)
                {
                    ArmstrongTest(n, r);
                }
            }
        }

        static int ParseArgToInt(string arg)
        {
            int result;
            int.TryParse(arg, out result);
            return result;
        }

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ArmstrongForm());
        }
    }
}
