using SudokuSolver.Sudoku;

namespace SudokuSolver.Solving
{
    public interface ISolvingStrategy
    {
        Cell[,] Solve(Cell[,] cells);
    }
}