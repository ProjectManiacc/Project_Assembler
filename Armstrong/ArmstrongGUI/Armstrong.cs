﻿

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

        public string Result { get; private set; }

        private int CountNumbers(int number)
        {
            return number.ToString().Length;
        }

        private int[] FillExponentMask(int digitsLength)
        {
            int[] exponentMask = new int[4];
            for (int i = 0; i < 4; i++)
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
                number = number / 10;

            }
            return result;


        }

        int CountArmstrongSumAsm(int[] digits)
        {

            int exponentMask = 4;//FillExponentMask(digits.Length);
            Console.WriteLine("DIGITS before asm: " + digits);
            int sum = asm_power(digits, exponentMask);

            return sum;
        }

        int CountArmstrongSumHighLevel(int[] digits)
        {

            int exponentMask = 4;//FillExponentMask(digits.Length);
            Console.WriteLine("DIGITS before asm: " + digits);
            Exponentation exponentation = new Exponentation();
            int sum = exponentation.Power(digits, exponentMask);

            return sum;
        }

        void ArmstrongTest(int number)
        {

            int[] digits = SplitNumber(1024);

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


        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ArmstrongForm());
        }
    }
}
