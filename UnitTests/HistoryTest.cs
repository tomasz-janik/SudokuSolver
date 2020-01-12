using Moq;
using NUnit.Framework;
using SudokuSolver.Model.Sudoku;

namespace UnitTests
{
    [TestFixture]
    public class HistoryTest
    {
        private History _history;
        private Cell _mockedCell;

        [SetUp]
        public void SetUp()
        {
            _history = new History();
            _mockedCell = new Mock<Cell>().Object;
        }

        [Test]
        public void ClearTest()
        {
            var mock = new Mock<Memento>(_mockedCell).Object;
            _history.AddUndoMemento(mock);

            _history.Clear();

            Assert.IsFalse(_history.IsUndoPossible());
        }

        [Test]
        public void IsUndoPossibleTest()
        {
            var mock = new Mock<Memento>(_mockedCell).Object;
            _history.AddUndoMemento(mock);
            
            Assert.IsTrue(_history.IsUndoPossible());
        }
        
        [Test]
        public void OrderTest()
        {
            var firstMock = new Mock<Memento>(_mockedCell).Object;
            var secondMock = new Mock<Memento>(_mockedCell).Object;

            _history.AddUndoMemento(firstMock);
            _history.AddUndoMemento(secondMock);
            
            var result = _history.GetUndoMemento();
            
            Assert.AreEqual(secondMock, result);
        }
    }
}