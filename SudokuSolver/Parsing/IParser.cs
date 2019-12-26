using System.Collections.Generic;
using SudokuSolver.Sudoku;

namespace SudokuSolver.Parsing
{
    public interface IParser<in T>
    {
        List<Cell> Parse(T content);
    }
}