using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using SudokuSolver.Model;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.ViewModel.Command;
using SudokuSolver.ViewModel.Provider;
using UnitTests.Provide;

namespace UnitTests.ViewModel.Command
{
    public class LoadSudokuCommandTest
    {
        private List<List<Cell>> _cells;
        private SudokuBoard _sudokuBoard;
        
        [SetUp]
        public void SetUp()
        {
            _cells = CellsProvider.Provide(9, State.InitialSet);
            
            _sudokuBoard = new SudokuBoard(new History());
            _sudokuBoard.CreateDefaultSudoku();
        }
        
        [Test]
        public void SuccessfulExecuteTest()
        {
            var fileProviderMock = new Mock<IFileProvider>();
            fileProviderMock.Setup(e => e.Provide(It.IsAny<string>())).Returns(_cells);
            
            
            var result = new LoadSudokuCommand(_sudokuBoard, fileProviderMock.Object).Execute(null);

            foreach (var cell in _sudokuBoard.Cells.SelectMany(lists => lists))
            {
                Assert.AreEqual(State.InitialSet, cell.State);
                Assert.AreEqual(9, cell.Value);
            }
            Assert.IsTrue(result);
        }
        
        [Test]
        public void UnsuccessfulExecuteTest()
        {
            var fileProviderMock = new Mock<IFileProvider>();
            fileProviderMock.Setup(e => e.Provide(It.IsAny<string>())).Returns(new List<List<Cell>>());
            
            var result = new LoadSudokuCommand(_sudokuBoard, fileProviderMock.Object).Execute(null);

            foreach (var cell in _sudokuBoard.Cells.SelectMany(lists => lists))
            {
                Assert.AreEqual(State.Unset, cell.State);
                Assert.IsNull(cell.Value);
            }
            Assert.IsFalse(result);
        }
    }
}