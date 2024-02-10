using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            armstrong.Result = ""; //clear output field
            bool isMinNumberEmpty = string.IsNullOrEmpty(minNumberInput.Text);
            bool isMaxNumberEmpty = string.IsNullOrEmpty(maxNumberInput.Text);
            bool isMinExponentEmpty = string.IsNullOrEmpty(minExponentInput.Text);
            bool isMaxExponentEmpty = string.IsNullOrEmpty(maxExponentInput.Text);
            if (isMinNumberEmpty)

            {
                outputText.Text = "Invalid input for minimum number.";
                return;
            }

            //Now all states are in nice brackets ready to add time measurment
            if (isMaxNumberEmpty)
            {
                if (isMinExponentEmpty)
                {
                    if (isMaxExponentEmpty) 
                    {
                        armstrong.ArmstrongTestHighLevel(int.Parse(minNumberInput.Text));
                    }
                    else 
                    {
                        armstrong.ArmstrongTestHighLevel(int.Parse(minNumberInput.Text), int.Parse(maxExponentInput.Text));
                    }
                }
                else

                {
                    if (isMaxExponentEmpty) 
                    {
                        armstrong.ArmstrongTestHighLevel(int.Parse(minNumberInput.Text), int.Parse(minExponentInput.Text));
                    }
                    else 
                    {
                        outputText.Text = "We didn't expect anyone would try such case.";
                        return;
                    }
                }
            }
            else
            {

                if (isMinExponentEmpty)
                {
                    if (isMaxExponentEmpty) 
                    {
                        armstrong.TrueArmstrongRange(int.Parse(minNumberInput.Text), int.Parse(maxNumberInput.Text));
                    }
                    else 
                    {
                        armstrong.ArmstrongRange(int.Parse(minNumberInput.Text), int.Parse(maxNumberInput.Text), int.Parse(maxExponentInput.Text));
                    }
                }
                else

                {
                    if (isMaxExponentEmpty) 
                    {
                        armstrong.ArmstrongRange(int.Parse(minNumberInput.Text), int.Parse(maxNumberInput.Text), int.Parse(minExponentInput.Text));
                    }
                    else 
                    {
                        armstrong.ArmstrongRange(int.Parse(minNumberInput.Text), int.Parse(maxNumberInput.Text), int.Parse(minExponentInput.Text), int.Parse(maxExponentInput.Text), int.Parse(threadsInput.Text));
                    }
                }
            }

            outputText.Text = armstrong.Result;
            if (string.IsNullOrEmpty(outputText.Text))
            {
                outputText.Text = "\nNo Armstrong number found in given ranges";
            }
            outputText.Text += Environment.NewLine;

        }

        private void title_Click(object sender, EventArgs e)
        {

        }
        
        // Don't let user type anything but digits in all 4 input fields.
        private void minNumberInput_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(minNumberInput.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                minNumberInput.Text = minNumberInput.Text.Remove(minNumberInput.Text.Length - 1);
            }
        }

        private void minExponentInput_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(minExponentInput.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                minExponentInput.Text = minExponentInput.Text.Remove(minExponentInput.Text.Length - 1);
            }
        }
        
        private void maxNumberInput_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(maxNumberInput.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                maxNumberInput.Text = maxNumberInput.Text.Remove(maxNumberInput.Text.Length - 1);
            }
        }

        private void maxExponentInput_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(maxExponentInput.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                maxExponentInput.Text = maxExponentInput.Text.Remove(maxExponentInput.Text.Length - 1);
            }
        }
        private void ThreadSliders_ValueChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(threadsInput.Value.ToString(), "^([1-9]|[0-5][0-9]|6[0-4])$"))
            {
                armstrong.SetThreadsSelected(Convert.ToInt32(threadsInput.Value));
            }
            else
            {
                MessageBox.Show("Threads cannot exceed 64 ");
                threadsInput.Value = 64;
            }
        }

    }
}
