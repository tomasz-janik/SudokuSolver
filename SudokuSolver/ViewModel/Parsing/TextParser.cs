using SudokuSolver.Model.Sudoku;
using SudokuSolver.ViewModel.Validation;

namespace SudokuSolver.ViewModel.Parsing
{
    public class TextParser : Parser<string>
    {
        private readonly IValidator _validator;
        private readonly IParser<string> _parser;

        public TextParser(IValidator validator, IParser<string> parser)
        {
            _validator = validator;
            _parser = parser;
        }

        protected override bool ValidateContent(string content)
        {
            return _validator.Validate(content);
        }

        protected override Cell[,] ParseContent(string content)
        {
            return _parser.Parse(content);
        }
    }
}