using System.Collections.Generic;
using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.ViewModel.Solving
{
    public interface ISolvingStrategy
    {
        bool Solve(List<List<Cell>> cells);
    }
}