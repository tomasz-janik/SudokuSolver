using System.Collections.Generic;
using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.ViewModel.Parsing
{
    public interface IParser<in T>
    {
        List<List<Cell>> Parse(T content);
    }
}