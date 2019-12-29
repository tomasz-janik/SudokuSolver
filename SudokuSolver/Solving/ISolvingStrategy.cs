using SudokuSolver.Digits;
using SudokuSolver.Sudoku;

namespace SudokuSolver.Solving
{
    public interface ISolvingStrategy
    {
        bool Solve(Cell[,] cells);
    }
}