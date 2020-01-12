using System.Linq;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.ViewModel.Provider;

namespace SudokuSolver.ViewModel.Command
{
    public class LoadSudokuCommand : ICommand
    {
        private readonly SudokuBoard _sudokuBoard;
        private readonly IFileProvider _fileProvider;

        public LoadSudokuCommand(SudokuBoard sudokuBoard, IFileProvider fileProvider)
        {
            _sudokuBoard = sudokuBoard;
            _fileProvider = fileProvider;
        }

        public bool Execute(string filename)
        {
            var result = _fileProvider.Provide(filename);
            if (!result.Any()) return false;

            _sudokuBoard.LoadSudoku(result);
            return true;

        }
    }
}