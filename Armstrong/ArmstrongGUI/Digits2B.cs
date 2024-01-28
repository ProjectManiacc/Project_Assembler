using System.Collections.Generic;

namespace ArmstrongGUI
{
    /** This class helps to store 4-elements array of 2 byte numbers.
    It's used to pass these arrays to assembler function for vector multiplying
    and later collect results and sum them up.
    */
    public class Digits2B
    {
        public int CountOfFours { get; private set; }

        public List<int[]> Fours { get; }



        public Digits2B(List<int> list)
        {
            CountOfFours = ((list.Count - 1) / 4 + 1);
            Fours = new List<int[]>();
            for (int i = 0; i < CountOfFours - 1; ++i)
            {
                int[] temp = {  list[4*i],
                                 list[4*i + 1],
                                 list[4*i + 2],
                                 list[4*i + 3]
                };
                Fours.Add(temp);
            }
            int startingNum = (CountOfFours - 1) * 4; //8
            int[] lastPiece = { 0, 0, 0, 0 };
            for (int i = startingNum; i < list.Count; ++i)
            {
                lastPiece[i - startingNum] = list[i];
            }
            Fours.Add(lastPiece);
        }

        public Digits2B()
        {
            CountOfFours = 0;
            Fours = new List<int[]>();
        }

        public void Add(int[] results)
        {
            ++CountOfFours;
            Fours.Add(results);
        }

    }
}
