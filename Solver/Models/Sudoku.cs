using System;
using System.Collections.Generic;
using System.Text;

namespace Solver.Models
{
    public class Sudoku<T>
    {
        public T[,] Digits { set; get; }

        public Sudoku()
        {
            Digits = new T[9,9];
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
    }
}
