using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;
using Solver.Models;

namespace Solver
{
    public interface ISudokuSolver
    {
        Sudoku<int> Solve(string pathImage);
    
    }
}
