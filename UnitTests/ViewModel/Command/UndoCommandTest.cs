using NUnit.Framework;
using SudokuSolver.Model;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.ViewModel.Command;

namespace UnitTests.ViewModel.Command
{
    public class UndoCommandTest
    {
        private History _history;

        [SetUp]
        public void SetUp()
        {
            _history = new History();
        }

        [TestCase(4)]
        public void PossibleUndoTest(int value)
        {
            var cell = new Cell();
            _history.AddUndoMemento(new Memento(cell));
            cell.Value = value;
            
            var result = new UndoCommand(_history).Execute("");
            
            Assert.IsTrue(result);
            Assert.AreEqual(State.Unset, cell.State);
            Assert.IsNull(cell.Value);
        }

        [Test]
        public void ImpossibleUndoTest()
        {
            var result = new UndoCommand(_history).Execute("");

            Assert.IsFalse(result);
        }
    }
}