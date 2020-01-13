using NUnit.Framework;
using SudokuSolver.ViewModel.Provider;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using SudokuGrabber;
using SudokuGrabber.Models;

namespace SudokuSolver.ViewModel.Provider.Tests
{
    [TestFixture()]
    public class ImageProviderTests
    {
        [Test()]
        public void ProvideTest()
        {
            var sudokuGrabber = new Mock<ISudokuGrabber>();
            var sudoku = new Sudoku<int>();

            var enumerator = (SudokuEnumerator<int>)sudoku.GetEnumerator();

            int i = 1;
            do
            {
                enumerator.SetValue(i++);
            } while (enumerator.MoveNext());

            sudokuGrabber.Setup(x => x.Grab(It.IsAny<string>())).Returns(sudoku);

            var imageProvider = new ImageProvider(sudokuGrabber.Object);
            var result = imageProvider.Provide("test");


            int expected = 1;
            foreach (var row in result)
            {
                foreach (var cell in row)
                {
                    Assert.AreEqual(expected++,cell.Value);
                }
            }

        }
    }
}