using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SudokuGrabber.Models
{
    public class Sudoku<T> : IEnumerable<T>
    {
        public T[,] Digits { set; get; }

        public Sudoku()
        {
            Digits = new T[9,9];
        }

        public IEnumerator<T> GetEnumerator()
        {
          return new SudokuEnumerator<T>(Digits);
        }

        public override string ToString()
        {
           var result = new StringBuilder();

           for (int i = 0; i < 9; i++)
           {
               for (int j = 0; j < 9; j++)
               {
                   result.Append(Digits[i, j] + "|");
               }

               result.Append('\n');
           }
           return result.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public List<List<T>> ToListOfList()
        {
            var result = new List<List<T>>();
            for (int i = 0; i < 9; i++)
            {
                var nextList = new List<T>();
                result.Add(nextList);
                for (int j = 0; j < 9; j++)
                {
                    nextList.Add(Digits[i,j]);
                }
            }

            return result;
        }
    }
}
