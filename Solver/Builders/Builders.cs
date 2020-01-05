using System;
using System.Collections.Generic;
using System.Text;

namespace Solver.Builders
{
    public static class  Builders
    {
       public static SolverBuilder NewSolverBuilder()
        {
            return new SolverBuilder();
        }

       public static BaseSudokuGrabberBuilder NewBaseSudokuGrabberBuilder()
       {
           return new BaseSudokuGrabberBuilder();
       }
    }
}
