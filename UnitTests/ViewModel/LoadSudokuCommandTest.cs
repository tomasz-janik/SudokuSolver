using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using SudokuSolver.Model;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.ViewModel.Command;
using SudokuSolver.ViewModel.Provider;

namespace UnitTests.ViewModel
{
    public class LoadSudokuCommandTest
    {
        [TestCase(9, 9, 2, true)]
        [TestCase(0, 0, 2, false)]
        public void ExecuteTest(int rows, int columns, int value, bool successful)
        {
            var cells = new List<List<Cell>>(rows);
            for (var i = 0; i < rows; i++)
            {
                var innerList = new List<Cell>(columns);
                for (var j = 0; j < columns; j++)
                {
                    innerList.Add(new Cell(value, State.InitialSet));
                }

                cells.Add(innerList);
            }
            var sudokuBoard = new SudokuBoard(new History()) {Cells = cells};
            var fileProviderMock = new Mock<IFileProvider>();
            fileProviderMock.Setup(e => e.Provide(It.IsAny<string>())).Returns(cells);
            
            var result = new LoadSudokuCommand(sudokuBoard, fileProviderMock.Object).Execute(null);

            foreach (var cell in sudokuBoard.Cells.SelectMany(lists => lists))
            {
                Assert.AreEqual(State.InitialSet, cell.State);
                Assert.AreEqual(value, cell.Value);
            }
            Assert.AreEqual(successful, result);
        }
    }
}