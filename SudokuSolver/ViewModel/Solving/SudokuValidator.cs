using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Model;
using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.ViewModel.Solving
{
    public static class SudokuValidator
    {
        private static bool IsInRow(IReadOnlyList<List<Cell>> cells, int? value, int row)
        {
            return cells[row].Any(cell => cell.Value == value);
        }

        private static bool IsInCol(IEnumerable<List<Cell>> cells, int? value, int column)
        {
            return cells.Any(row => row[column].Value == value);
        }
        
        
        private static bool IsInBox(IReadOnlyList<List<Cell>> cells, int? value, int row, int column) {
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

        public static bool IsValid(List<List<Cell>> cells, int? value, int row, int column) {
            return !IsInRow(cells, value, row) && !IsInCol(cells, value, column) && 
                   !IsInBox(cells, value, row, column);
        }
        
        private static bool IsRowValid(IReadOnlyList<List<Cell>> cells, int row)
        {
            var usedNumbers = new bool[10];
            for (var i = 0; i < cells[row].Count; i++)
            {
                if (cells[row][i].State == State.Unset) continue;
                if (usedNumbers[cells[row][i].Value ?? default])
                {
                    return false;
                }

                usedNumbers[cells[row][i].Value ?? default] = true;
            }

            return true;
        }

        private static bool IsColValid(IReadOnlyList<List<Cell>> cells, int column)
        {
            var usedNumbers = new bool[10];
            for (var i = 0; i < cells[0].Count; i++)
            {
                if (cells[i][column].State == State.Unset) continue;
                if (usedNumbers[cells[i][column].Value ?? default])
                {
                    return false;
                }

                usedNumbers[cells[i][column].Value ?? default] = true;
            }

            return true;
        }

        
        private static bool IsBoxValid(IReadOnlyList<List<Cell>> cells, int row, int column)
        {
            var boxRow = row - row % 3;
            var boxColumn = column - column % 3;

            var usedNumbers = new bool[10];
            for (var i = boxRow; i < boxRow + 3; i++)
            {
                for (var j = boxColumn; j < boxColumn + 3; j++)
                {
                    if (cells[i][j].State == State.Unset) continue;
                    if (usedNumbers[cells[i][j].Value ?? default])
                    {
                        return false;
                    }

                    usedNumbers[cells[i][j].Value ?? default] = true;
                }
            }

            return true;
        }
        
        public static bool IsValid(List<List<Cell>> cells)
        {
            for (var i = 0; i < cells.Count; i++)
            {
                if (!IsRowValid(cells, i))
                {
                    return false;
                }
            }

            for (var j = 0; j < cells[0].Count; j++)
            {
                if (!IsColValid(cells, j))
                {
                    return false;
                }
            }

            for (var i = 0; i < cells.Count; i += 3)
            {
                for (var j = 0; j < cells[0].Count; j += 3)
                {
                    if (!IsBoxValid(cells, i, j))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}