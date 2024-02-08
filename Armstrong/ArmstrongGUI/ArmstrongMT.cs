using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArmstrongGUI;
using ExponentationNamespace;

namespace ArmstrongGUI_MT
{
    class Armstrong
    {
        //Krystian laptop
        //[DllImport(@"D:\studia\sem5\JA\Project_Assembler\Armstrong\x64\Debug\Assembler.dll")]
        //Piotrek 
        [DllImport(@"C:\Users\piotrek\Desktop\Project_Assembler\Armstrong\x64\Debug\Assembler.dll")]
        public static extern int asm_power(int[] digits, int exponent);

        //Collector for output message
        public string Result { get; private set; }

        private int maxThreads = Environment.ProcessorCount;
        private int threadsSelected = Environment.ProcessorCount;
        private List<int> properThreadsValue = new List<int> { 1, 2, 4, 8, 16, 32, 64 };
        public void SetThreadsSelected(int threads)
        {
            if (properThreadsValue.Contains(threads))
            {
                this.threadsSelected = threads;
                return;
            }
            this.threadsSelected = maxThreads;
        }

        public int CountArmstrongSum(Digits digits, int exponent)
        {
            int sum = 0;
            for (int i = 0; i < digits.CountOfFours(); ++i)
            {
                sum += asm_power(digits.fours[i], exponent);
            }
            return sum;
        }

        private int CountNumbers(int number)
        {
            return number.ToString().Length;
        }

        int[] SplitNumber(int number)
        {
            Console.WriteLine("number before split: " + number);
            int numberLength = CountNumbers(number);
            int[] result = new int[numberLength];
            for (int i = 0; i < numberLength; ++i)
            {
                result[i] = number % 10;
                number = number / 10;
            }
            return result;
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


        public void ArmstrongTest(int number)
        {
            Result = "";
            Digits digits = new Digits(number);
            int exponent = digits.CountDigits();
            if (number == CountArmstrongSum(digits, exponent))
                PrintArmstrongTestResultMessage(number, exponent);
        }

        public void ArmstrongTest(int number, int exponent)
        {
            Result = "";
            Digits digits = new Digits(number);
            if (number == CountArmstrongSum(digits, exponent))
                PrintArmstrongTestResultMessage(number, exponent);
        }

        public void ArmstrongRange(int numMin, int numMax, int exponentMin)
        {
            Result = "";
            Parallel.For(numMin, numMax + 1, n =>
            {
                ArmstrongTest(n, exponentMin);
            });
        }

        public void ArmstrongRange(int numMin, int numMax, int exponentMin, int exponentMax)
        {
            Result = "";
            Parallel.For(exponentMin, exponentMax + 1, r =>
            {
                for (int n = numMin; n <= numMax; ++n)
                {
                    ArmstrongTest(n, r);
                }
            });
        }

        public void TrueArmstrongRange(int numMin, int numMax)
        {
            Result = "";
            Parallel.For(numMin, numMax + 1, i =>
            {
                ArmstrongTest(i);
            });
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
