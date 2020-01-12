using System.Linq;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.ViewModel.Parsing;
using SudokuSolver.ViewModel.Reading;

namespace SudokuSolver.ViewModel.Command
{
    public class LoadSudokuCommand : ICommand
    {
        private readonly SudokuBoard _sudokuBoard;
        private readonly Reader<string> _reader;
        private readonly Parser<string> _parser;

        public LoadSudokuCommand(SudokuBoard sudokuBoard, Reader<string> reader, Parser<string> parser)
        {
            _sudokuBoard = sudokuBoard;
            _reader = reader;
            _parser = parser;
        }

        public bool Execute(string filename)
        {
            var readingResult = _reader.Read(filename);
            if (string.IsNullOrEmpty(readingResult)) return false;
            
            var parsingResult = _parser.Parse(readingResult);
            if (!parsingResult.Any()) return false;
            
            _sudokuBoard.LoadSudoku(parsingResult);
            
            return true;
        }
    }
}