using NUnit.Framework;
using SudokuSolver.ViewModel.Validation;

namespace UnitTests.ViewModel.Validation
{
    public class TextFileValidatorTest
    {
        [TestCase("initial.txt", true)]
        [TestCase("initial.tx", false)]
        [TestCase("initial.", false)]
        [TestCase("initial.txt.jpg", false)]
        public void ValidateTest(string filename, bool expected)
        {
            var result = new TextFileValidator().Validate(filename);
            
            Assert.AreEqual(expected, result);
        }
    }
}