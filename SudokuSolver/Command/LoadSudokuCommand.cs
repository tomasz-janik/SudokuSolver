using SudokuSolver.Parsing;
using SudokuSolver.Reading;
using SudokuSolver.Sudoku;

namespace SudokuSolver.Command
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

        public void Execute(string filename)
        {
            _sudokuBoard.Cells = _parser.Parse(_reader.Read(filename));
        }
    }
}