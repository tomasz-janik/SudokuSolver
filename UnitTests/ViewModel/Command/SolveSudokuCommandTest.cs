using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SudokuSolver.Model;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.ViewModel.Command;
using SudokuSolver.ViewModel.Solving;
using SudokuSolver.ViewModel.Solving.Factory;
using UnitTests.Provide;

namespace UnitTests.ViewModel.Command
{
    public class SolveSudokuCommandTest
    {
        private SudokuBoard _sudokuBoard;
        private History _history;
        
        [SetUp]
        public void SetUp()
        {
            var cells = CellsProvider.Provide(2, State.InitialSet);
            
            _history = new History();
            _history.AddUndoMemento(new Memento(new Cell()));
            _sudokuBoard = new SudokuBoard(_history) {Cells = cells};
        }
        
        [Test]
        public void FailedSolvingTest()
        {
            var solvingStrategy = new Mock<ISolvingStrategy>();
            var solvingStrategyFactory = new Mock<ISolvingStrategyFactory>();

            solvingStrategy.Setup(e => e.Solve(It.IsAny<List<List<Cell>>>())).Returns(false);
            solvingStrategyFactory.Setup(e => e.GetSolvingStrategy(It.IsAny<string>()))
                .Returns(solvingStrategy.Object);

            var result = new SolveSudokuCommand(_sudokuBoard, solvingStrategyFactory.Object).Execute("strategy");

                        
            Assert.IsFalse(result);
            Assert.AreEqual(_history.IsUndoPossible(), true);
        }
        
        [Test]
        public void SucceededSolvingTest()
        {
            var solvingStrategy = new Mock<ISolvingStrategy>();
            var solvingStrategyFactory = new Mock<ISolvingStrategyFactory>();

            solvingStrategy.Setup(e => e.Solve(It.IsAny<List<List<Cell>>>())).Returns(true);
            solvingStrategyFactory.Setup(e => e.GetSolvingStrategy(It.IsAny<string>()))
                .Returns(solvingStrategy.Object);

            var result = new SolveSudokuCommand(_sudokuBoard, solvingStrategyFactory.Object).Execute("strategy");

                        
            Assert.IsTrue(result);
            Assert.AreEqual(_history.IsUndoPossible(), false);
        }
    }
}