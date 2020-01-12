using System.Linq;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.ViewModel.Parsing;
using SudokuSolver.ViewModel.Provider;
using SudokuSolver.ViewModel.Reading;

namespace SudokuSolver.ViewModel.Command
{
    public class LoadSudokuCommand : ICommand
    {
        private readonly SudokuBoard _sudokuBoard;
        private IFileProvider _fileProvider;
        private readonly Reader<string> _reader;
        private readonly Parser<string> _parser;
        
        public LoadSudokuCommand(SudokuBoard sudokuBoard, IFileProvider fileProvider)
        {
            _sudokuBoard = sudokuBoard;
            _fileProvider = fileProvider;
            //_reader = reader;
            //_parser = parser;
        }

        public bool Execute(string filename)
        {
            var result = _fileProvider.Provide(filename);
            if (!result.Any()) return false;

            _sudokuBoard.ChangeCells(result);
            return true;

        }
    }
}