using System;
using System.Collections.Generic;
using System.Text;
using SudokuSolver.Model;
using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.Extensions
{
    static class IntExtensions
    {
        public static Cell ToCell(this int value)
        {
            return value == 0 ? new Cell() : new Cell(value, State.InitialSet);
        }
    }
}
