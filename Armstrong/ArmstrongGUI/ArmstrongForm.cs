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




        private  void calculateButton_Click(object sender, EventArgs e)
        {
            

            int minNumber, maxNumber, minExponent, maxExponent;

            if (!int.TryParse(minNumberInput.Text, out minNumber))
            {
                outputText.Text = "Invalid input for minimum number.";
                return;
            }

            if (!string.IsNullOrEmpty(maxExponentInput.Text))
            {
                minExponent = int.Parse(minExponentInput.Text);
                maxExponent = int.Parse(maxExponentInput.Text);
                maxNumber = int.Parse(maxNumberInput.Text);

                
                    armstrong.ArmstrongRange(minNumber, maxNumber);
                outputText.Text = armstrong.Result + Environment.NewLine;
            }
            else if (!string.IsNullOrEmpty(maxNumberInput.Text))
            {
                maxNumber = int.Parse(maxNumberInput.Text);

                
                    armstrong.ArmstrongRange(minNumber, maxNumber );
                outputText.Text = armstrong.Result + Environment.NewLine;
            }
            else if (!string.IsNullOrEmpty(minExponentInput.Text))
            {
                minExponent = int.Parse(minExponentInput.Text);
                
                    armstrong.ArmstrongRange(minNumber, minNumber);
                
                outputText.Text = armstrong.Result;
                if (string.IsNullOrEmpty(outputText.Text))
                {
                    outputText.Text = "\nThis is not Armstrong's number";
                }
                outputText.Text += Environment.NewLine;
            }
            else
            {
                
                    armstrong.ArmstrongRange(minNumber, minNumber);
                outputText.Text = armstrong.Result;
                if (string.IsNullOrEmpty(outputText.Text))
                {
                    outputText.Text = "\nThis is not Armstrong's number";
                }
                outputText.Text += Environment.NewLine;
            }

        }

        private void title_Click(object sender, EventArgs e)
        {

        }
    }
}
