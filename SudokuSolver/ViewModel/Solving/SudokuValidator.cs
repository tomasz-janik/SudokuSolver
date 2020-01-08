using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.ViewModel.Solving
{
    public static class SudokuValidator
    {
        private static bool IsInRow(IReadOnlyList<List<Cell>> cells, int value, int row)
        {
            return cells[row].Any(cell => cell.Value == value);
        }

        private static bool IsInCol(IReadOnlyCollection<List<Cell>> cells, int value, int column)
        {
            return cells.Any(row => row[column].Value == value);
        }
        
        
        private static bool IsInBox(List<List<Cell>> cells, int value, int row, int column) {
            var boxRow = row - row % 3;
            var boxColumn = column - column % 3;

            for (var i = boxRow; i < boxRow + 3; i++)
            {
                for (var j = boxColumn; j < boxColumn + 3; j++)
                {
                    if (cells[i][j].Value == value)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        public static bool IsValid(List<List<Cell>> cells, int value, int row, int column) {
            return !IsInRow(cells, value, row) && !IsInCol(cells, value, column) && 
                   !IsInBox(cells, value, row, column);
        }
    }
}