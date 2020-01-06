using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Model.Digits;
using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.ViewModel.Solving
{
    public class PreSolvingStrategy : ISolvingStrategy
    {
        private readonly DigitFactory _digitFactory;

        public PreSolvingStrategy(DigitFactory digitFactory)
        {
            _digitFactory = digitFactory;
        }

        public bool Solve(List<List<Cell>> cells)
        {
            var possibilities = new List<Digit>[cells.Count, cells[0].Count];

            return PreSolve(cells, possibilities) && Solve(cells, possibilities);
        }

        private static bool Solve(List<List<Cell>> cells, List<Digit>[,] possibilities)
        {
            for (var row = 0; row < cells.Count; row++)
            {
                for (var col = 0; col < cells[row].Count; col++)
                {
                    if (cells[row][col].State != State.Unset) continue;

                    foreach (var digit in possibilities[row, col]
                        .Where(digit => SudokuValidator.IsValid(cells, digit, row, col)))
                    {
                        cells[row][col].SolverSet(digit);

                        if (Solve(cells, possibilities))
                        {
                            return true;
                        }

                        cells[row][col].Unset();
                    }

                    return false;
                }
            }

            return true;
        }

        private bool PreSolve(List<List<Cell>> cells, List<Digit>[,] canPlace)
        {
            for (var row = 0; row < cells.Count; row++)
            {
                for (var col = 0; col < cells[row].Count; col++)
                {
                    if (cells[row][col].State != State.Unset) continue;

                    canPlace[row, col] = new List<Digit>();
                    for (var number = 1; number <= cells.Count; number++)
                    {
                        var digit = _digitFactory[number];
                        if (SudokuValidator.IsValid(cells, digit, row, col))
                        {
                            canPlace[row, col].Add(digit);
                        }
                    }

                    switch (canPlace[row, col].Count)
                    {
                        case 0:
                            return false;
                        case 1:
                            cells[row][col].SolverSet(canPlace[row, col].First());
                            break;
                    }
                }
            }

            return true;
        }
    }
}