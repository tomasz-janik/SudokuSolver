using System.Linq;
using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.ViewModel.Command
{
    public class ClearSudokuCommand : ICommand
    {
        private readonly SudokuBoard _sudokuBoard;
        
        public ClearSudokuCommand(SudokuBoard sudokuBoard)
        {
            _sudokuBoard = sudokuBoard;
        }
        
        public bool Execute(string _)
        {
            foreach (var cell in _sudokuBoard.Cells.SelectMany(row => row))
            {
                cell.Unset();
            }

            return true;
        }
    }
}