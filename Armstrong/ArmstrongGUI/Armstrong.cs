using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace ArmstrongGUI
{


    class Armstrong
    {
        //Krystian laptop
        //[DllImport(@"D:\studia\sem5\JA\Project_Assembler\Armstrong\x64\Debug")]
        //Piotrek 
        [DllImport(@"C:\Users\piotrek\Desktop\Project_Assembler\Armstrong\x64\Debug\Assembler.dll")]
        public static extern int asm_power(int[] digits, int exponent);

        public string Result { get; set; }
        Stopwatch stopwatchAsm = new Stopwatch();
        Stopwatch stopwatchHighLevel = new Stopwatch();


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
            this.threadsSelected = (maxThreads > 64 ? 64 : maxThreads);
        }

        public int CountArmstrongSumAsm(Digits digits, int exponent)
        {
            int sum = 0;
            for (int i = 0; i < digits.CountOfFours(); ++i)
            {
                sum += asm_power(digits.fours[i], exponent);
            }
            return sum;
        }

        public int CountArmstrongSumHighLevel(Digits digits, int exponent)
        {
            int sum = 0;
            for (int i = 0; i < digits.CountOfFours(); ++i)
            {
                sum += Exponentation.Power(digits.fours[i], exponent);
            }
            return sum;
        }

        private int CountNumbers(int number)
        {
            return number.ToString().Length;
        }

        int[] SplitNumber(int number)
        {
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


        public void ArmstrongTestAsm(int number)
        {
            Digits digits = new Digits(number);
            int exponent = digits.CountDigits();

            stopwatchAsm.Start();
            if (number == CountArmstrongSumAsm(digits, exponent))
                PrintArmstrongTestResultMessage(number, exponent);
            stopwatchAsm.Stop();
        }

        public void ArmstrongTestAsm(int number, int exponent)
        {
            Digits digits = new Digits(number);

            stopwatchAsm.Start();
            if (number == CountArmstrongSumAsm(digits, exponent))
                PrintArmstrongTestResultMessage(number, exponent);
            stopwatchAsm.Stop();
        }

        public void ArmstrongTestHighLevel(int number)
        {
            Digits digits = new Digits(number);
            int exponent = digits.CountDigits();

            stopwatchHighLevel.Start();
            if (number == CountArmstrongSumHighLevel(digits, exponent))
                PrintArmstrongTestResultMessage(number, exponent);
            stopwatchHighLevel.Stop();
        }

        public void ArmstrongTestHighLevel(int number, int exponent)
        {
            Digits digits = new Digits(number);

            stopwatchHighLevel.Start();
            if (number == CountArmstrongSumHighLevel(digits, exponent))
                PrintArmstrongTestResultMessage(number, exponent);
            stopwatchHighLevel.Stop();
        }

        public void ArmstrongRange(int numMin, int numMax, int exponentMin, int threadsCount)
        {
            stopwatchAsm.Reset();
            stopwatchHighLevel.Reset();

            int rangePerThread = (numMax - numMin + 1) / threadsCount;
            CountdownEvent countdownEventHighLevel = new CountdownEvent(threadsCount);

            for (int i = 0; i < threadsCount; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback((state) =>
                {
                    int start = numMin + ((int)state * rangePerThread);
                    int end = Math.Min(numMax, start + rangePerThread - 1);
                    for (int n = start; n <= end; n++)
                    {
                            ArmstrongTestHighLevel(n, exponentMin);
                        
                    }
                    countdownEventHighLevel.Signal();
                }), i);
            }
            countdownEventHighLevel.Wait();
            long elapsedHighLevel = stopwatchHighLevel.ElapsedMilliseconds;
            Console.WriteLine("Execution time - C#: " + elapsedHighLevel);
            countdownEventHighLevel.Dispose();


            CountdownEvent countdownEventAsm = new CountdownEvent(threadsCount);
            for (int i = 0; i < threadsCount; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback((state) =>
                {
                    int start = numMin + ((int)state * rangePerThread);
                    int end = Math.Min(numMax, start + rangePerThread - 1);
                    for (int n = start; n <= end; n++)
                    {
                       
                            ArmstrongTestAsm(n, exponentMin);
                        
                    }
                    countdownEventAsm.Signal();
                }), i);
            }

            countdownEventAsm.Wait();
            long elapsedAsm = stopwatchAsm.ElapsedMilliseconds;
            Console.WriteLine("Execution time - Assembler: " + elapsedAsm);
            countdownEventAsm.Dispose();
        }

        public void ArmstrongRange(int numMin, int numMax, int exponentMin, int exponentMax, int threadsCount)
        {
            stopwatchAsm.Reset();
            stopwatchHighLevel.Reset();

            int rangePerThread = (numMax - numMin + 1) / threadsCount;
            CountdownEvent countdownEventHighLevel = new CountdownEvent(threadsCount);

            for (int i = 0; i < threadsCount; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback((state) =>
                {
                    int start = numMin + ((int)state * rangePerThread);
                    int end = Math.Min(numMax, start + rangePerThread - 1);
                    for (int n = start; n <= end; n++)
                    {
                        for (int r = exponentMin; r <= exponentMax; r++)
                        {
                            ArmstrongTestHighLevel(n, r);
                        }
                    }
                    countdownEventHighLevel.Signal();
                }), i);
            }
            countdownEventHighLevel.Wait();
            long elapsedHighLevel = stopwatchHighLevel.ElapsedMilliseconds;
            Console.WriteLine("Execution time - C#: " + elapsedHighLevel);
            countdownEventHighLevel.Dispose();


            CountdownEvent countdownEventAsm = new CountdownEvent(threadsCount);
            for (int i = 0; i < threadsCount; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback((state) =>
                {
                    int start = numMin + ((int)state * rangePerThread);
                    int end = Math.Min(numMax, start + rangePerThread - 1);
                    for (int n = start; n <= end; n++)
                    {
                        for (int r = exponentMin; r <= exponentMax; r++)
                        {
                            ArmstrongTestAsm(n, r);
                        }
                    }
                    countdownEventAsm.Signal();
                }), i);
            }

            countdownEventAsm.Wait();
            long elapsedAsm = stopwatchAsm.ElapsedMilliseconds;
            Console.WriteLine("Execution time - Assembler: " + elapsedAsm);
            countdownEventAsm.Dispose();

        }

        public void TrueArmstrongRange(int numMin, int numMax, int threadsCount)
        {
            stopwatchAsm.Reset();
            stopwatchHighLevel.Reset();

            int rangePerThread = (numMax - numMin + 1) / threadsCount;
            CountdownEvent countdownEventHighLevel = new CountdownEvent(threadsCount);

            for (int i = 0; i < threadsCount; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback((state) =>
                {
                    int start = numMin + ((int)state * rangePerThread);
                    int end = Math.Min(numMax, start + rangePerThread - 1);
                    for (int n = start; n <= end; n++)
                    {
                        ArmstrongTestHighLevel(n);

                    }
                    countdownEventHighLevel.Signal();
                }), i);
            }
            countdownEventHighLevel.Wait();
            long elapsedHighLevel = stopwatchHighLevel.ElapsedMilliseconds;
            Console.WriteLine("Execution time - C#: " + elapsedHighLevel);
            countdownEventHighLevel.Dispose();


            CountdownEvent countdownEventAsm = new CountdownEvent(threadsCount);
            for (int i = 0; i < threadsCount; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback((state) =>
                {
                    int start = numMin + ((int)state * rangePerThread);
                    int end = Math.Min(numMax, start + rangePerThread - 1);
                    for (int n = start; n <= end; n++)
                    {

                        ArmstrongTestAsm(n);

                    }
                    countdownEventAsm.Signal();
                }), i);
            }

            countdownEventAsm.Wait();
            long elapsedAsm = stopwatchAsm.ElapsedMilliseconds;
            Console.WriteLine("Execution time - Assembler: " + elapsedAsm);
            countdownEventAsm.Dispose();
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
