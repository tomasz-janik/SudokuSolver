using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Model;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.Utils;

namespace SudokuSolver.ViewModel.Parsing
{
    public class TextFileParser : IParser<string>
    {
        public List<List<Cell>> Parse(string content)
        {
            return content.Select(letter => int.TryParse(letter.ToString(), out var value)
                    ? new Cell(value, State.InitialSet)
                    : new Cell(value, State.Unset))
                .ToGroup(9)
                .ToDoubleList(9);
        }
    }
}