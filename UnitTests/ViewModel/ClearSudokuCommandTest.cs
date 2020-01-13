using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SudokuSolver.Model;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.ViewModel.Command;

namespace UnitTests.ViewModel
{
    public class ClearSudokuCommandTest
    {
        [TestCase(9, 9)]
        [TestCase(0, 0)]
        public void ExecuteTest(int rows, int columns)
        {
            var cells = new List<List<Cell>>(rows);
            for (var i = 0; i < rows; i++)
            {
                var innerList = new List<Cell>(columns);
                for (var j = 0; j < columns; j++)
                {
                    innerList.Add(new Cell(j + 1, State.SolverSet));
                }

                cells.Add(innerList);
            }
            var sudokuBoard = new SudokuBoard(new History()) {Cells = cells};
            
            var result = new ClearSudokuCommand(sudokuBoard).Execute(null);

            foreach (var cell in sudokuBoard.Cells.SelectMany(lists => lists))
            {
                Assert.AreEqual(State.Unset, cell.State);
                Assert.IsNull(cell.Value);
            }
            
            Assert.AreEqual(true, result);
        }
    }
}