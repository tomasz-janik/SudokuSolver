using NUnit.Framework;
using Solver.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Solver.Grabber.Digit;
using Solver.Grabber.Sudoku;
using Solver.Recognizer;

namespace Solver.Filters.Tests
{
    [TestFixture()]
    public class CenterImageTests
    {
        [Test()]
        public void ApplyTest()
        {
            // Arrange
            var centerImage = new CenterImage(28);

            // Act

            // Assert
        }
    }
}