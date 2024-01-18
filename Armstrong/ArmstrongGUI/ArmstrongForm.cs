using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ArmstrongGUI
{
    
    public partial class ArmstrongForm : Form
    {
        Armstrong armstrong = new Armstrong();
        public ArmstrongForm()
        {
            InitializeComponent();
        }

        private void ArmstrongForm_Load(object sender, EventArgs e)
        {
            outputText.Text = "Armstrong Number Checker GUI" + Environment.NewLine;
            outputText.Text += "Usage:" + Environment.NewLine;
            outputText.Text += "1. ./armstrong minNumber\t\t\t\t\t- Test if a number with n digits equals the sum of digits each to the power of n." + Environment.NewLine;
            outputText.Text += "2. ./Armstrong minNumber minExponent\t\t\t\t- Test if it's an Armstrong's number for the given power." + Environment.NewLine;
            outputText.Text += "3. ./armstrong minNumber maxNumber minExponent\t\t- Search all Armstrong numbers in the range <number1, number2> for the power of 'exponent'." + Environment.NewLine;
            outputText.Text += "4. ./armstrong minNumber maxNumber minExponent maxExponent\t- Search all Armstrong numbers in the range <num1, num2> for all powers from 'exponent1' to 'exponent2' (inclusive)." + Environment.NewLine;
            outputText.Text += Environment.NewLine + "Please consider the time it can take if ranges are too wide." + Environment.NewLine;
            outputText.Text += Environment.NewLine + "Authors:" + Environment.NewLine;
            outputText.Text += "\tKrystian Gagracz" + Environment.NewLine;
            outputText.Text += "\tPiotr Kluziok" + Environment.NewLine;
            outputText.Text += "\tPawel Mielimonka" + Environment.NewLine;
        }
        private async void calculateButton_Click(object sender, EventArgs e)
        {
            int minNumber, maxNumber, minExponent, maxExponent;
            bool isMinNum = int.TryParse(minNumberInput.Text, out minNumber);
            bool isMaxNum = int.TryParse(maxNumberInput.Text, out maxNumber);
            bool isMinExp = int.TryParse(minExponentInput.Text, out minExponent);
            bool isMaxExp = int.TryParse(maxExponentInput.Text, out maxExponent) && isMinExp;
            //at this point we know what was parsable, and it's already parsed.
            if (!isMinNum)
            {
                outputText.Text = "Invalid input for minimum number.";
                return;
            }

            if (isMaxExp)
            {
                await Task.Run(() => armstrong.ArmstrongRange(minNumber, maxNumber, minExponent, maxExponent));
            }
            else 
            {
                if (isMaxNum)
                {
                    if (isMinExp)
                    {
                        await Task.Run(() => armstrong.ArmstrongRange(minNumber, maxNumber, minExponent));
                    }
                    else
                    {
                        await Task.Run(() => armstrong.TrueArmstrongRange(minNumber, maxNumber));
                    }
                }
                else
                {
                    if (isMinExp) 
                    {
                        await Task.Run(() => armstrong.ArmstrongTest(minNumber, minExponent));
                    }
                    else
                    {
                        await Task.Run(() => armstrong.ArmstrongTest(minNumber));
                    }
                }
            }
            if (string.IsNullOrEmpty(armstrong.Result))
            {
                outputText.Text = "\nNo Armstroong's number found within given boundaries!\n";
            }
            else 
            {
                outputText.Text = armstrong.Result;
            }
        }

        private void title_Click(object sender, EventArgs e)
        {

        }
    }
}
