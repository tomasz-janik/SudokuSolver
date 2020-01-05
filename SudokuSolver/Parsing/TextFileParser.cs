using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Digits;
using SudokuSolver.Sudoku;
using SudokuSolver.Utils;

namespace SudokuSolver.Parsing
{
    public class TextFileParser : IParser<string>
    {
        private readonly DigitFactory _digitFactory;

        public TextFileParser(DigitFactory digitFactory)
        {
            _digitFactory = digitFactory;
        }

        public Cell[,] Parse(string content)
        {
            return content.Select(letter =>
                {
                    int.TryParse(letter.ToString(), out var value);
                    return _digitFactory[value];
                })
                //todo refactor this select
                .Select(digit => digit == _digitFactory.Default ? new Cell(digit, State.Unset) : new Cell(digit, State.InitialSet))
                .ToGroup(9)
                .ToRectangularArray(9);
        }
    }
}