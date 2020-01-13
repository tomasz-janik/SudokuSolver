using System.Linq;
using NUnit.Framework;
using SudokuSolver.Model;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.ViewModel.Command;
using UnitTests.Provide;

namespace UnitTests.ViewModel.Command
{
    public class ClearSudokuCommandTest
    {
        private SudokuBoard _sudokuBoard;
        
        [SetUp]
        public void SetUp()
        {
            var cells = CellsProvider.Provide(2, State.InitialSet);
            _sudokuBoard = new SudokuBoard(new History()) {Cells = cells};   
        }
        
        [Test]
        public void ExecuteTest()
        {
            var result = new ClearSudokuCommand(_sudokuBoard).Execute(null);

            foreach (var cell in _sudokuBoard.Cells.SelectMany(lists => lists))
            {
                Assert.AreEqual(State.Unset, cell.State);
                Assert.IsNull(cell.Value);
            }
            
            Assert.IsTrue(result);
        }
    }
}