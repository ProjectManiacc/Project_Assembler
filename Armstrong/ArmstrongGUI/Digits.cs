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
            int countOfFours = ((countOfDigits - 1) / 4 + 1);
            fours = new List<int[]>();
            int[] allDigits = splitNumber(number);
            int offset = 0;
            for (int i = 0; i < countOfFours - 1; ++i)
            {
                offset = 4*i;
                int[] temp = {allDigits[offset], allDigits[offset+1], allDigits[offset+2], allDigits[offset+3]};
                fours.Add(temp);
            }
            int[] lastPiece = { 0, 0, 0, 0 };
            offset += 4;
            for (int i = offset; i < countOfDigits - offset; ++i)
            {
                lastPiece[i - offset] = allDigits[i];
            }
            fours.Add(lastPiece);
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
