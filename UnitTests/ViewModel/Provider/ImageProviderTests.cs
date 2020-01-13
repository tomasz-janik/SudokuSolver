using System.Linq;
using Moq;
using NUnit.Framework;
using SudokuGrabber;
using SudokuGrabber.Models;
using SudokuSolver.ViewModel.Provider;

namespace UnitTests.ViewModel.Provider
{
    [TestFixture]
    public class ImageProviderTests
    {
        [Test]
        public void ProvideTest()
        {
            var sudokuGrabber = new Mock<ISudokuGrabber>();
            var sudoku = new Sudoku<int>();

            var enumerator = (SudokuEnumerator<int>)sudoku.GetEnumerator();

            var i = 1;
            do
            {
                enumerator.SetValue(i++);
            } while (enumerator.MoveNext());

            sudokuGrabber.Setup(x => x.Grab(It.IsAny<string>())).Returns(sudoku);

            var imageProvider = new ImageProvider(sudokuGrabber.Object);
            var result = imageProvider.Provide("test");


            var expected = 1;
            foreach (var cell in result.SelectMany(row => row))
            {
                Assert.AreEqual(expected++,cell.Value);
            }

        }
    }
}