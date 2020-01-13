using System.Linq;
using NUnit.Framework;
using SudokuSolver.Model;
using SudokuSolver.ViewModel.Parsing;

namespace UnitTests.ViewModel.Parsing
{
    [TestFixture]
    public class TextFileParserText
    {
        [Test]
        public void EmptyContentParseTest()
        {
            var textFileParser = new TextFileParser();

            var content = new string(' ', 81);
            var result = textFileParser.Parse(content);

            foreach (var cell in result.SelectMany(cells => cells))
            {
                Assert.IsNull(cell.Value);
                Assert.AreEqual(State.Unset, cell.State);
            }
        }
        
        [Test]
        public void ContentParseTest()
        {
            var textFileParser = new TextFileParser();
            
            var content = new string('1', 81);
            var result = textFileParser.Parse(content);

            foreach (var cell in result.SelectMany(cells => cells))
            {
                Assert.AreEqual(1,cell.Value);
                Assert.AreEqual(State.InitialSet, cell.State);
            }
        }
    }
}