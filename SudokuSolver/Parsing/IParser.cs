using System.Collections.Generic;
using SudokuSolver.Sudoku;

namespace SudokuSolver.Parsing
{
    public interface IParser<in T>
    {
        Cell[,] Parse(T content);
    }
}