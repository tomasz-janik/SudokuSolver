using System.Collections.Generic;
using SudokuSolver.Model;
using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.ViewModel.Solving
{
    public class BacktrackingStrategy : ISolvingStrategy
    {
        public bool Solve(List<List<Cell>> cells)
        {
            return SudokuValidator.IsValid(cells) && Resolve(cells);
        }

        private static bool Resolve(List<List<Cell>> cells)
        {
            for (var row = 0; row < cells.Count; row++)
            {
                for (var col = 0; col < cells[row].Count; col++)
                {
                    if (cells[row][col].State != State.Unset) continue;
                    for (var number = 1; number <= 9; number++)
                    {
                        if (!SudokuValidator.IsValid(cells, number, row, col)) continue;

                        cells[row][col].SolverSet(number);
          
                        if (Resolve(cells)) {
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