using System.Collections.Generic;

namespace ArmstrongGUI
{
    /** This class helps to store 4-elements arrays of 4 byte int.
    It's used to pass these arrays to assembler function for vector multiplying.
    */
    public class Digits
    {
        private int countOfDigits;
        private int countOfFours;
        public List<int[]> fours { get; }
        
        public Digits(int number)
        {
            countOfDigits = number.ToString().Length;
            countOfFours = ((countOfDigits - 1) / 4 + 1);
            fours = new List<int[]>();
            int[] allDigits = splitNumber(number);
            for (int i = 0; i < countOfFours; ++i) 
            {
                fours.Add(new int[] { 0,0,0,0});
            }
            for (int i = 0; i < countOfDigits; ++i) {
                setSingle(i, allDigits[i]);
            }
            //for (int i = 0; i < countOfDigits; ++i) Condole.print("  " + getSingle(i));
        }

        private int getSingle(int position) 
        {
            int four = position / 4;
            position -= (4*four);
            return (fours[four])[position];
        }
        
        private void setSingle(int position, int val) 
        {
            int four = position / 4;
            position -= (4*four);
            (fours[four])[position] = val;
        }
        
        public int CountDigits() {
            return countOfDigits;
        }

        public int CountOfFours()
        {
            return fours.Count;
        }

        public void Add(int[] fourDigits)
        {
            if (fourDigits.Length != 4) return;
            ++countOfFours;
            fours.Add(fourDigits);
        }

        public void Add(int digit) {
            if (digit > 9 || digit < 0) return;
            if (countOfDigits % 4 == 0) {
                int[] temp = {digit, 0, 0, 0};
                Add(temp);
            } else {
                //in last four I have (countOfDigits - 4*fours.Count + 4) digits, so that's the index of position for new digit
                fours[fours.Count - 1][countOfDigits - 4*fours.Count + 4] = digit;
            }
            ++countOfDigits;
        }

        private int[] splitNumber(int number)
        {            
            int size = number.ToString().Length;
            int[] result = new int[size];
            for (int i = size - 1; i >= 0; --i)
            {
                result[i] = number % 10;
                number = number / 10;
            }
            return result;
        }
    }
}
