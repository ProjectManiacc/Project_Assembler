using System.Collections.Generic;

namespace ArmstrongGUI
{
  /** This class is a container for 2 numbers 4 bytes each with helper methods
  which enable easy passing consecutive digits to assembler vector function
  taking such pairs as parameter. It also helps collecting results and sums them up.
  */
  public class Digits4B
  {
      
      public int CountOfTwos { get; private set; }
  
      public List<int[]> Twos { get; }
  
      public Digits4B(List<int> list)
      {
          CountOfTwos = ((list.Count >> 1) + (list.Count & 1));
          Twos = new List<int[]>();
          for (int i = 0; i < CountOfTwos - 1; ++i)
          {
              int[] temp = { (short)list[2*i], (short)list[2*i + 1] };
              Twos.Add(temp);
          }
          //now, I don't want to care IF there are digits left (1 or 0)
          //so i cut it this way there are either 1 or 2 numbers
          int startingNum = (CountOfTwos - 1) * 2; 
          int[] lastPiece = { 0, 0 };
          for (int i = startingNum; i < list.Count; ++i)
          {
              lastPiece[i - startingNum] = (short)list[i];
          }
          //now i have {x,y} or {x,0}, no other option.
          Twos.Add(lastPiece);
      }

      public Digits4B()
      {
          CountOfTwos = 0;
          Twos = new List<int[]>();
      }

      public void Add(int[] results)
      {
          ++CountOfTwos;
          Twos.Add(results);
      }
                         
      public int Sum()
      {
          int sum = 0;
          for (int i = 0; i < CountOfTwos; ++i)
          {
              for (int j = 0; j < 4; ++j)
              {
                  sum += Twos[i][j];
              }
          }
          return sum;
      }
   }
}
