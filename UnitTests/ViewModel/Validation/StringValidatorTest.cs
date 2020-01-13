using NUnit.Framework;
using SudokuSolver.ViewModel.Validation;

namespace UnitTests.ViewModel.Validation
{
    public class StringValidatorTest
    {
        [Test]
        public void ContentLengthTooShortTest()
        {
            var content = new string('1', 80);
            var result = new StringValidator().Validate(content);
            
            Assert.IsFalse(result);
        }
        
        [Test]
        public void ContentLengthTooLongTest()
        {
            var content = new string('1', 82);
            var result = new StringValidator().Validate(content);
            
            Assert.IsFalse(result);
        }
        
        [Test]
        public void ContentInvalidCharactersTest()
        {
            var content = new string('p', 81);
            var result = new StringValidator().Validate(content);
            
            Assert.IsFalse(result);
        }
        
        [Test]
        public void ContentValidTest()
        {
            var content = new string('1', 81);
            var result = new StringValidator().Validate(content);
            
            Assert.IsTrue(result);
        }
    }
}