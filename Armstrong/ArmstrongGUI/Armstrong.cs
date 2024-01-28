

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ExponentationNamespace;

namespace ArmstrongGUI
{
    class Armstrong
    {
        [DllImport(@"C:\Users\piotrek\Desktop\Project_Assembler\Armstrong\x64\Debug\Assembler.dll")]
        public static extern int asm_power(int[] digits, int exponent);
        //[DllImport(@"C:\Users\piotrek\Desktop\Project_Assembler\Armstrong\Exponentation\bin\Debug\Exponentation.dll")]
        //public static extern int power(int[] digits, int exponent);

        //Collector for output message
        public string Result { get; private set; }


        /*int Power(int x, int y)
        {
            // We don't want to import a whole math library for just integer power.
            int result = 1;
            for (int i = 0; i < y; ++i)
            {
                result *= x;
            }
            return result;
        }*/

        private int CountNumbers(int number)
        {
            return number.ToString().Length;
        }

        private int[] FillExponentMask(int digitsLength)
        {
            int[] exponentMask = new int[4];
            for (int i = 0;i < 4; i++)
            {
                exponentMask[i] = CountNumbers(digitsLength);
            }

            return exponentMask;
        }

        int[] SplitNumber(int number)
        {
            Console.WriteLine("number before split: " + number);
            int numberLength = CountNumbers(number);

            int[] result = new int[numberLength];
            for (int i = 0; i < numberLength; ++i)
            {
                result[i] = number % 10;
                Console.WriteLine(i + ": " + result[i]);
                number = number / 10;

            }
            Console.WriteLine("number after split:" + result.ToString());
            return result;
            

        }

        int CountArmstrongSum(int[] digits)
        {

            int exponentMask = 4;//FillExponentMask(digits.Length);
            Console.WriteLine("DIGITS before asm: " + digits);
            //int sum = asm_power(digits, exponentMask);
            Exponentation exponentation = new Exponentation();
            int sum = exponentation.Power(digits, exponentMask);
            //int sum = 0;
            //Console.WriteLine("DIGISTS:");

            
            Console.WriteLine("SUM"+sum);

            return sum;
        }

        void ArmstrongTest(int number)
        {
            /*Result = "";
            int[] digits = SplitNumber(number);
            
            if (number == CountArmstrongSum(digits))
                PrintArmstrongTestResultMessage(number, digits.Length);*/

            int[] digits = SplitNumber(1024);
            Console.WriteLine(CountArmstrongSum(digits));
            //PrintArmstrongTestResultMessage(CountArmstrongSum(digits), 4);

        }


        public void ArmstrongRange(int numMin, int numMax)
        {
            Result = "";

            for (int n = numMin; n <= numMax; ++n)
                {
                    ArmstrongTest(n);
                }
            
        }
        void PrintArmstrongTestResultMessage(int number, int exponent)
        {
            int[] digits = SplitNumber(number);
            StringBuilder resultBuilder = new StringBuilder();
            foreach (var i in digits)
            {
                resultBuilder.Append($"{i}^{exponent} + ");
            }
            resultBuilder.Remove(resultBuilder.Length - 2, 2); // Remove the trailing " + "
            resultBuilder.Append($"= {number}");
            resultBuilder.AppendLine();
            resultBuilder.Append($"This is Armstrong's number for the power of {exponent}.");
            resultBuilder.AppendLine();
            Result += resultBuilder.ToString();
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
        /*int CountArmstrongSum(List<int> numbers, int exponent)
        {
            if (exponent < 2 || exponent > 10) return 0; //instead of throwing
            if (exponent < 6) return CountArmstrongSum2To5(numbers, (short)exponent);
            return CountArmstrongSum6To10(numbers, exponent);                
        }

        int CountArmstrongSum2To5(List<int> numbers, short exponent)
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
                asm_power6(vectors.Twos[i], exponent, out i1, out i2);
                int[] ret = {i1, i2};
                result.Add(ret);
            }
            return result.Sum();
        }

        void PrintArmstrongTestResultMessage(int number, int exponent)
        {
            List<int> digits = SplitNumber(number);
            StringBuilder resultBuilder = new StringBuilder();
            foreach (var i in digits)
            {
                resultBuilder.Append($"{i}^{exponent} + ");
            }
            resultBuilder.Remove(resultBuilder.Length - 2, 2); // Remove the trailing " + "
            resultBuilder.Append($"= {number}");
            resultBuilder.AppendLine();
            resultBuilder.Append($"This is Armstrong's number for the power of {exponent}.");
            resultBuilder.AppendLine();
            Result += resultBuilder.ToString();
        }

        public void ArmstrongTest(int number)
        {
            Result = "";
            List<int> digits = SplitNumber(number);
            int exponent = digits.Count;
            if (number == CountArmstrongSum(digits, exponent))
                PrintArmstrongTestResultMessage(number, exponent);
        }

        public void ArmstrongTest(int number, int exponent)
        {
            Result = "";
            if (number == CountArmstrongSum(SplitNumber(number), exponent))
                PrintArmstrongTestResultMessage(number, exponent);
        }

        public void ArmstrongRange(int numMin, int numMax, int exponentMin)
        {
            Result = "";
            for (int n = numMin; n <= numMax; ++n)
            {
                ArmstrongTest(n, exponentMin);
            }
        }
                
        public void ArmstrongRange(int numMin, int numMax, int exponentMin, int exponentMax)
        {
            Result = "";
            for (int r = exponentMin; r <= exponentMax; ++r)
            {
                for (int n = numMin; n <= numMax; ++n)
                {
                    ArmstrongTest(n, r);
                }
            }
        }

        public void TrueArmstrongRange(int numMin, int numMax)
        {
            Result = "";
            for (int i = numMin; i <= numMax; ++i)
            {
                ArmstrongTest(i);
            }
        }*/



        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ArmstrongForm());
        }
    }
}
