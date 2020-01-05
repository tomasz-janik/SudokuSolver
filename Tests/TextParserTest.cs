using NUnit.Framework;
using SudokuSolver.Digits;
using SudokuSolver.Parsing;
using SudokuSolver.Validation;

namespace Tests
{
    public class TextParserTest
    {
        private Parser<string> _textParser;
        [SetUp]
        public void Setup()
        {
            _textParser = new TextParser(new StringValidator(), new TextFileParser(new DigitFactory()));
        }

        [Test]
        public void Test1()
        {
            //Assert.AreEqual(81, _textParser.Parse("111111112222222233333333444444445555555566666666777777777778888888888899999999999").Length);
            //Assert.AreEqual(State.Unset, _textParser.Parse(".11111112222222233333333444444445555555566666666777777777778888888888899999999999")[0].State);
        }
    }
}