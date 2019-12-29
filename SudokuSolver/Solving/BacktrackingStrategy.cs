using SudokuSolver.Digits;
using SudokuSolver.Sudoku;

namespace SudokuSolver.Solving
{
    //todo - decide if should pass cells into every function or leave is as private field
    public class BacktrackingStrategy : ISolvingStrategy
    {
        private DigitFactory _digitFactory;
        private Cell[,] _cells;

        public BacktrackingStrategy(DigitFactory digitFactory)
        {
            _digitFactory = digitFactory;
        }

        public bool Solve(Cell[,] cells)
        {
            _cells = cells;
            for (var row = 0; row < cells.Length; row++) {
                for (var col = 0; col < cells.Length; col++) {
                    if (cells[row, col].State != State.Unset) continue;
                    for (var number = 1; number <= 9; number++)
                    {
                        var digit = _digitFactory[number];
                        if (!SudokuValidator.IsValid(cells, digit, row, col)) continue;
                        
                        cells[row, col].SolverSet(digit);
          
                        if (Solve(cells)) {
                            return true;
                        } else {
                            cells[row, col].Unset();
                        }
                    }
		
                    return false;
                }
            }
  
            return true;
        }
    }
}