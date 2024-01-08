

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
        extern static int asm_power(int first_number, int last_number);
        public string Result { get; private set; }


        static int Power(int x, int y)
        {
            // We don't want to import a whole math library for just integer power.
            int result = 1;
            for (int i = 0; i < y; ++i)
            {
                result *= x;
            }
            return result;
        }

        static List<int> SplitNumber(int number)
        {
            List<int> result = new List<int>();
            while (number >= 1)
            {
                result.Add((int)(number - 10 * (number / 10)));
                number /= 10;
            }
            return result;
        }

        static int GetSumOfNumberDigitsPower(List<int> numbers, int exponent)
        {
            int sum = 0;
            foreach (var i in numbers)
            {
                //sum += asm_power(i, exponent);
                sum += Power(i, exponent);
            }
            return sum;
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
            int sum = GetSumOfNumberDigitsPower(digits, exponent);
            PrintArmstrongTestResultMessage(sum == number, number, exponent);
        }

        public void ArmstrongTest(int number, int exponent)
        {
            List<int> digits = SplitNumber(number);
            int sum = GetSumOfNumberDigitsPower(digits, exponent);
            PrintArmstrongTestResultMessage(sum == number, number, exponent);
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
