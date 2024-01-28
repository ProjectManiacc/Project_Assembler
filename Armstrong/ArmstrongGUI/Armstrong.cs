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
        public static extern int asm_power(int[] digits, int exponent);
        //Collector for output message
        public string Result { get; private set; }

        public int CountArmstrongSum(Digits digits, int exponent) {
            int sum = 0;
            for (int i = 0; i < digits.CountOfFours(); ++i) {
                sum += asm_power(digits.fours[i], exponent);
            }
            return sum;
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
            Digits digits = new Digits(number);
            int exponent = digits.Count();
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
