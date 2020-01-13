using Moq;
using NUnit.Framework;
using SudokuSolver.Model;
using SudokuSolver.Model.Sudoku;

namespace UnitTests.Model
{
    [TestFixture]
    public class SudokuBoardTest
    {
        private SudokuBoard _sudokuBoard;

        [SetUp]
        public void SetUp()
        {
            var historyMock = new Mock<History>().Object;
            _sudokuBoard = new SudokuBoard(historyMock);
        }
        
        [Test]
        public void DefaultSudokuTest()
        {
            _sudokuBoard.CreateDefaultSudoku();
            
            foreach (var cells in _sudokuBoard.Cells)
            {
                foreach (var cell in cells)
                {
                    Assert.AreEqual(State.Unset, cell.State);
                    Assert.IsNull(cell.Value);
                }
            }
        }
    }
}