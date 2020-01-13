using NUnit.Framework;
using SudokuSolver.Model;
using SudokuSolver.ViewModel.Parsing;
using SudokuSolver.ViewModel.Validation;

namespace UnitTests.ViewModel
{
    public class TextParserTest
    {
        private Parser<string> _textParser;
        
        [SetUp]
        public void Setup()
        {
            _textParser = new TextParser(new StringValidator(), new TextFileParser());
        }

        [Test]
        public void Test1()
        {
            //Assert.AreEqual(81, _textParser.Parse("111111112222222233333333444444445555555566666666777777777778888888888899999999999"));
            //Assert.AreEqual(State.Unset, _textParser.Parse(".11111112222222233333333444444445555555566666666777777777778888888888899999999999")[0].State);
        }
    }
}