using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.ViewModel.Parsing
{
    public interface IParser<in T>
    {
        Cell[,] Parse(T content);
    }
}