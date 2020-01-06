using System.Collections.Generic;
using SudokuSolver.Model.Digits;
using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.ViewModel.Solving
{
    public class BacktrackingStrategy : ISolvingStrategy
    {
        private readonly DigitFactory _digitFactory;

        public BacktrackingStrategy(DigitFactory digitFactory)
        {
            _digitFactory = digitFactory;
        }

        public bool Solve(List<List<Cell>> cells)
        {
            for (var row = 0; row < cells.Count; row++)
            {
                for (var col = 0; col < cells[row].Count; col++)
                {
                    if (cells[row][col].State != State.Unset) continue;
                    for (var number = 1; number <= 9; number++)
                    {
                        var digit = _digitFactory[number];
                        if (!SudokuValidator.IsValid(cells, digit, row, col)) continue;

                        cells[row][col].SolverSet(digit);
          
                        if (Solve(cells)) {
                            return true;
                        }

                        cells[row][col].Unset();
                    }
                    
                    return false;
                }
            }
            
            return true;
        }
    }
}