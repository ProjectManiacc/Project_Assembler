/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArmstrongGUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
            /*else{
                Result = "\nThis is not an Armstrong's number";
            }*/
                
            
            // Console.WriteLine("\nThis is not an Armstrong's number");
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

            /*
            //Console.WriteLine("I AM WORKING");
            if (args.Length < 1)
            {
                // User provided no arguments - print usage info
                Console.WriteLine("\nUsage:");
                Console.WriteLine("./armstrong number\t\t\ttest if number with n digits equals sum of digits each to power of n");
                Console.WriteLine("./Armstrong number exponent\ttest if Armstrong's number for power of 'exponent'");
                Console.WriteLine("./armstrong number1 number2 exponent\tsearch all Armstrong numbers in range <number1,number2> for power of 'exponent'");
                Console.WriteLine("./armstrong num1 num2 exponent1 exponent2\tsearch all Armstrong numbers in range <num1,num2> for all powers from 'exponent1' to 'exponent2' including.");
                Console.WriteLine("Please consider time it can take if ranges are too wide");
                Console.WriteLine("Authors:");
                Console.WriteLine("\tKrystian Gagracz");
                Console.WriteLine("\tPiotr Kluziok");
                Console.WriteLine("\tPawel Mielimonka\n");
            }
            else if (args.Length == 1)
            {
                // 1 argument: number to test.
                //ArmstrongTest(ParseArgToInt(args[0]));
            }
            else if (args.Length == 2)
            {
                // 2 arguments: {number, exponent}
                //ArmstrongTest(ParseArgToInt(args[0]), ParseArgToInt(args[1]));
            }
            else if (args.Length == 3)
            {
                // 3 arguments: {numMin, numMax, exponent}
                // Faster loop when end condition doesn't call a function every time. The same for exponent.
                // int nmax = ParseArgToInt(args[2]);
                // int exponent = ParseArgToInt(args[3]);
                // for (int n = ParseArgToInt(args[1]); n <= nmax; ++n) ArmstrongTest(n, exponent);
                Thread t = new Thread(() => ArmstrongRange(ParseArgToInt(args[0]), ParseArgToInt(args[1]), ParseArgToInt(args[2]), ParseArgToInt(args[2])));
                t.Start();
                t.Join();
            }
            else if (args.Length > 3)
            {
                // 4 arguments: {1: numMin, 2: numMax, 3: exponentMin, 4: exponentMax}
                // Faster loop when end condition doesn't call a function every time.
                Thread t = new Thread(() => ArmstrongRange(ParseArgToInt(args[0]), ParseArgToInt(args[1]), ParseArgToInt(args[2]), ParseArgToInt(args[3])));
                t.Start();
                t.Join();
                int minTestedNumber = ParseArgToInt(args[1]);
                int maxTestedNumber = ParseArgToInt(args[2]);
                int minExponent = ParseArgToInt(args[3]);
                int maxExponent = ParseArgToInt(args[4]);
                for (int r = minExponent; r <= maxExponent; ++r)
                    for (int n = minTestedNumber; n <= maxTestedNumber; ++n)
                        ArmstrongTest(n, r);
                
            }
            */
        }
    }
}
