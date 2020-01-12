using System;
using System.Collections.Generic;
using System.Text;
using SudokuSolver.Model.Digits;
using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.Extensions
{
    static class IntExtensions
    {
        public static Cell ToCell(this int value)
        {
            return new Cell(value,State.InitialSet);
            
        }
    }
}
