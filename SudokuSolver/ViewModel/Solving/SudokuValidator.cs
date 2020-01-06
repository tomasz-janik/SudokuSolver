using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Model.Digits;
using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.ViewModel.Solving
{
    public static class SudokuValidator
    {
        private static bool IsInRow(IReadOnlyList<List<Cell>> cells, Digit digit, int row)
        {
            return cells[row].Any(cell => cell.Digit == digit);
        }

        private static bool IsInCol(IReadOnlyCollection<List<Cell>> cells, Digit digit, int column)
        {
            return cells.Any(row => row[column].Digit == digit);
        }
        
        
        private static bool IsInBox(List<List<Cell>> cells, Digit digit, int row, int column) {
            var boxRow = row - row % 3;
            var boxColumn = column - column % 3;

            for (var i = boxRow; i < boxRow + 3; i++)
            {
                for (var j = boxColumn; j < boxColumn + 3; j++)
                {
                    if (cells[i][j].Digit == digit)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        public static bool IsValid(List<List<Cell>> cells, Digit digit, int row, int column) {
            return !IsInRow(cells, digit, row) && !IsInCol(cells, digit, column) && 
                   !IsInBox(cells, digit, row, column);
        }
    }
}