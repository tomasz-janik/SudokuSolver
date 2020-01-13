using NUnit.Framework;
using SudokuSolver.Model;
using SudokuSolver.Model.Sudoku;

namespace UnitTests.Model
{
    [TestFixture]
    public class CellTest
    {
        [Test]
        public void NullConstructorTest()
        {
            var cell = new Cell(null, State.Unset);   
            
            Assert.AreEqual(State.Unset, cell.State);
            Assert.IsNull(cell.Value);
        }
        
        [TestCase(3)]
        public void ValidConstructorTest(int value)
        {
            var cell = new Cell(value, State.UserSet);   
            
            Assert.AreEqual(State.UserSet, cell.State);
            Assert.AreEqual(value, cell.Value);
        }
        
        [TestCase(5)]
        public void NullValueSetTest(int value)
        {
            var cell = new Cell(value, State.UserSet);

            cell.Value = null;
            
            Assert.AreEqual(State.Unset, cell.State);
            Assert.IsNull(cell.Value);
        }

        [TestCase(5)]
        public void ValidValueSetTest(int value)
        {
            var cell = new Cell();

            cell.Value = value;
            
            Assert.AreEqual(State.UserSet, cell.State);
            Assert.AreEqual(value, cell.Value);
        }
        
        [Test]
        public void InitialValuesTest()
        {
            var cell = new Cell();
            
            Assert.AreEqual(State.Unset, cell.State);
            Assert.IsNull(cell.Value);
        }
        
        [Test]
        public void UnsetTest()
        {
            var cell = new Cell();
            cell.Unset();
            
            Assert.AreEqual(State.Unset, cell.State);
            Assert.IsNull(cell.Value);
        }
        
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(9)]
        public void SolverSetTest(int value)
        {
            var cell = new Cell();
            cell.SolverSet(value);
            
            Assert.AreEqual(State.SolverSet, cell.State);
            Assert.AreEqual(value, cell.Value);
        }
    }
}