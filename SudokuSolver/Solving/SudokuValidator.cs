using SudokuSolver.Digits;
using SudokuSolver.Sudoku;

namespace SudokuSolver.Solving
{
    public static class SudokuValidator
    {
        private static bool IsInRow(Cell[,] cells, Digit digit, int row) {
            for (var i = 0; i < 9; i++)
            {
                if (cells[row, i].Digit == digit)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsInCol(Cell[,] cells, Digit digit, int column) {
            for (var i = 0; i < 9; i++)
            {
                if (cells[i, column].Digit == digit)
                {
                    return true;
                }
            }
            
            return false;
        }
        
        
        private static bool IsInBox(Cell[,] cells, Digit digit, int row, int column) {
            var boxRow = row - row % 3;
            var boxColumn = column - column % 3;

            for (var i = boxRow; i < boxRow + 3; i++)
            {
                for (var j = boxColumn; j < boxColumn + 3; j++)
                {
                    if (cells[i, j].Digit == digit)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        public static bool IsValid(Cell[,] cells, Digit digit, int row, int column) {
            return !IsInRow(cells, digit, row) && !IsInCol(cells, digit, column) && 
                   !IsInBox(cells, digit, row, column);
        }
    }
}