using NUnit.Framework;
using SudokuSolver.ViewModel.Parsing;
using SudokuSolver.ViewModel.Solving;
using SudokuSolver.ViewModel.Validation;

namespace Tests
{
    public class BacktrackingStrategyTest
    {
        private BacktrackingStrategy _backtrackingStrategy;
        
        [SetUp]
        public void Setup()
        {
            _backtrackingStrategy = new BacktrackingStrategy();
        }
        
        [Test]
        public void InvalidSudokuTest()
        {
            //given
            var parser = new TextParser(new StringValidator(), new TextFileParser());
            var cells = parser.Parse(".11111112222222233333333444444445555555566666666777777777778888888888899999999999");
            
            Assert.AreEqual(false, _backtrackingStrategy.Solve(cells));
        }
        
        [Test]
        public void SudokuTest()
        {
            //given
            var parser = new TextParser(new StringValidator(), new TextFileParser());
            var cells = parser.Parse("........1........2........3........4........5........6........7........8........9");
            
            Assert.AreEqual(true, _backtrackingStrategy.Solve(cells));
        }
    }
}