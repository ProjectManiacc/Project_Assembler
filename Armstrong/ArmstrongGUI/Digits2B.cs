namespace ArmstrongGUI
{
  /** This class helps to store 4-elements array of 2 byte numbers.
  It's used to pass these arrays to assembler function for vector multiplying
  and later collect results and sum them up.
  */
  public class Digits2B
    {
        public short CountOfFours { get; private set; }
    
        public List<short[]> Fours { get; }
    
        public Digits2B(List<int> list)
        {
            CountOfFours = (short)((list.Count - 1) / 4 + 1);
            Fours = new List<short[]>();
            for (int i = 0; i < CountOfFours - 1; ++i)
            {
                short[] temp = {  (short)list[4*i],
                                  (short)list[4*i + 1],
                                  (short)list[4*i + 2],
                                  (short)list[4*i + 3]
                };
                Fours.Add(temp);
            }
            int startingNum = (CountOfFours - 1) * 4; //8
            short[] lastPiece = { 0, 0, 0, 0 };
            for (int i = startingNum; i < list.Count; ++i)
            {
                lastPiece[i - startingNum] = (short)list[i];
            }
            Fours.Add(lastPiece);
        }

        public Digits2B()
        {
            CountOfFours = 0;
            Fours = new List<short[]>();
        }

        public void Add(short[] results)
        {
            ++CountOfFours;
            Fours.Add(results);
        }
        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < CountOfFours; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    sum += (int)Fours[i][j];
                }
            }
            return sum;
        }
    }
}
