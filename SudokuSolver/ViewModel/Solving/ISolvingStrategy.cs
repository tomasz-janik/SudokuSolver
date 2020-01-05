using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.ViewModel.Solving
{
    public interface ISolvingStrategy
    {
        bool Solve(Cell[,] cells);
    }
}