using Moq;
using NUnit.Framework;
using Solver;
using Solver.Grabber.Digit;
using Solver.Grabber.Sudoku;
using Solver.Recognizer;

namespace SolverTests
{
    [TestFixture()]
    public class SudokuSolverTests
    {
        [Test()]
        public void SolveTest()
        {
          // Arrange
          var sudokuGrabberMock = new Mock<ISudokuPositionGrabber>();
          var digitGrabberMock = new Mock<IDigitGrabber>();
          var digitRecognizerMock = new Mock<IDigitRecognizer>();

          var sudokuSolver =
              new SudokuGrabber(sudokuGrabberMock.Object, digitGrabberMock.Object, digitRecognizerMock.Object);

          // Act
          
          // Assert
        }
    }
}