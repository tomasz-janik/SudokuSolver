using System.Collections.Generic;
using SudokuSolver.Model;
using SudokuSolver.Model.Sudoku;

namespace UnitTests.Provide
{
    public static class CellsProvider
    {
        private const int Rows = 9;
        private const int Columns = 9;

        public static List<List<Cell>> Provide(int value, State state)
        {
            var cells = new List<List<Cell>>(Rows);
            for (var i = 0; i < Rows; i++)
            {
                var innerList = new List<Cell>(Columns);
                for (var j = 0; j < Columns; j++)
                {
                    innerList.Add(new Cell(value, state));
                }

                cells.Add(innerList);
            }

            return cells;
        }
    }
}