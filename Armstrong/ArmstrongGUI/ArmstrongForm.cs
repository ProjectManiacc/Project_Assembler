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
            outputText.Text = "Usage:\n";
            outputText.Text += "./armstrong number\t\t\ttest if number with n digits equals sum of digits each to power of n\n";
            outputText.Text += "./Armstrong number exponent\ttest if Armstrong's number for power of 'exponent'\n";
            outputText.Text += "./armstrong number1 number2 exponent\tsearch all Armstrong numbers in range <number1,number2> for power of 'exponent'\n";
            outputText.Text += "./armstrong num1 num2 exponent1 exponent2\tsearch all Armstrong numbers in range <num1,num2> for all powers from 'exponent1' to 'exponent2' including.\n";
            outputText.Text += "Please consider time it can take if ranges are too wide\n";
            outputText.Text += "Authors:\n";
            outputText.Text += "\tKrystian Gagracz\n";
            outputText.Text += "\tPiotr Kluziok\n";
            outputText.Text += "\tPawel Mielimonka\n";
        }


        private void calculateButton_Click(object sender, EventArgs e)
        {
            // Clear the outputText at the beginning of each click
            outputText.Text = "This is not Armstrong's number";

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

                armstrong.ArmstrongRange(minNumber, maxNumber, minExponent, maxExponent);
                outputText.Text = armstrong.Result + Environment.NewLine;
            }
            else if (!string.IsNullOrEmpty(maxNumberInput.Text))
            {
                minExponent = int.Parse(minExponentInput.Text);
                maxNumber = int.Parse(maxNumberInput.Text);

                armstrong.ArmstrongRange(minNumber, maxNumber, minExponent, minExponent);
                outputText.Text = armstrong.Result + Environment.NewLine;
            }
            else if (!string.IsNullOrEmpty(minExponentInput.Text))
            {
                minExponent = int.Parse(minExponentInput.Text);
                armstrong.ArmstrongRange(minNumber, minNumber, minExponent, minExponent);
                outputText.Text = armstrong.Result;
                if (string.IsNullOrEmpty(outputText.Text))
                {
                    outputText.Text = "\nThis is not Armstrong's number";
                }
                outputText.Text += Environment.NewLine;
            }
            else
            {
                armstrong.ArmstrongRange(minNumber, minNumber, 3, 3);
                outputText.Text = armstrong.Result;
                if (string.IsNullOrEmpty(outputText.Text))
                {
                    outputText.Text = "\nThis is not Armstrong's number";
                }
                outputText.Text += Environment.NewLine;
            }

            bool check = true;
        }

    }
}
