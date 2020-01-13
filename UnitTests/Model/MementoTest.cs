using NUnit.Framework;
using SudokuSolver.Model;
using SudokuSolver.Model.Sudoku;

namespace UnitTests.Model
{
    public class MementoTest
    {
        
        [TestCase(5)]
        public void RestoreEmptyCellTest(int newValue)
        {
            var cell = new Cell();
            var memento = new Memento(cell);
            cell.Value = newValue;
            
            memento.Restore();
            
            Assert.AreEqual(State.Unset,cell.State);
            Assert.IsNull(cell.Value);
        }

        [TestCase(9, 5)]
        public void RestoreCellTest(int previousValue, int newValue)
        {
            var cell = new Cell(previousValue, State.UserSet);
            var memento = new Memento(cell);
            cell.Value = newValue;
            
            memento.Restore();
            
            Assert.AreEqual(State.UserSet,cell.State);
            Assert.AreEqual(previousValue, cell.Value);
        }

    }
}