using System.Linq;
using NUnit.Framework;
using SudokuSolver.Model;
using SudokuSolver.ViewModel.Parsing;
using SudokuSolver.ViewModel.Validation;

namespace UnitTests.ViewModel.Parsing
{
    [TestFixture]
    public class TextParserTest
    {
        [Test]
        public void InvalidStringTest()
        {
            var stringValidator = new StringValidator();
            var textFileParser = new TextFileParser();
            
            var parser = new TextParser(stringValidator, textFileParser);
            var result = parser.Parse("string");

            Assert.IsNull(result);
        }
        
        [Test]
        public void ValidStringTest()
        {
            var stringValidator = new StringValidator();
            var textFileParser = new TextFileParser();
            
            var parser = new TextParser(stringValidator, textFileParser);
            
            var content = new string('1', 81);
            var result = parser.Parse(content);

            foreach (var cell in result.SelectMany(cells => cells))
            {
                Assert.AreEqual(1, cell.Value);
                Assert.AreEqual(State.InitialSet, cell.State);
            }
        }
    }
}