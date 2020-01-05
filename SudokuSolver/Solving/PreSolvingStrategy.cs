using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Digits;
using SudokuSolver.Sudoku;

namespace SudokuSolver.Solving
{
    public class PreSolvingStrategy : ISolvingStrategy
    {
        private readonly DigitFactory _digitFactory;

        public PreSolvingStrategy(DigitFactory digitFactory)
        {
            _digitFactory = digitFactory;
        }

        public bool Solve(Cell[,] cells)
        {
            var possibilities = new List<Digit>[cells.GetLength(0), cells.GetLength(1)];

            var a = PreSolve(cells, possibilities);
            var b = Solve(cells, possibilities);
            return a && b;
        }

        private bool Solve(Cell[,] cells, List<Digit>[,] possibilities)
        {
            for (var row = 0; row < cells.GetLength(0); row++)
            {
                for (var col = 0; col < cells.GetLength(1); col++)
                {
                    if (cells[row, col].State != State.Unset) continue;

                    foreach (var digit in possibilities[row, col])
                    {
                        if (!SudokuValidator.IsValid(cells, digit, row, col)) continue;

                        cells[row, col].SolverSet(digit);

                        if (Solve(cells, possibilities))
                        {
                            return true;
                        }

                        cells[row, col].Unset();
                    }

                    return false;
                }
            }

            return true;
        }

        private bool PreSolve(Cell[,] cells, List<Digit>[,] canPlace)
        {
            for (var i = 0; i < cells.GetLength(0); i++)
            {
                for (var j = 0; j < cells.GetLength(1); j++)
                {
                    if (cells[i, j].State != State.Unset) continue;

                    canPlace[i, j] = new List<Digit>();
                    for (var number = 1; number <= cells.GetLength(0); number++)
                    {
                        var digit = _digitFactory[number];
                        if (SudokuValidator.IsValid(cells, digit, i, j))
                        {
                            canPlace[i, j].Add(digit);
                        }
                    }

                    switch (canPlace[i, j].Count)
                    {
                        case 0:
                            return false;
                        case 1:
                            cells[i, j].SolverSet(canPlace[i, j].First());
                            break;
                    }
                }
            }

            return true;
        }
    }
}