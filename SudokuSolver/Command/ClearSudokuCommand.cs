using SudokuSolver.Sudoku;

namespace SudokuSolver.Command
{
    public class ClearSudokuCommand : ICommand
    {
        private readonly SudokuBoard _sudokuBoard;
        
        ClearSudokuCommand(SudokuBoard sudokuBoard)
        {
            _sudokuBoard = sudokuBoard;
        }
        
        public void Execute(string _)
        {
            foreach (var sudokuBoardCell in _sudokuBoard.Cells)
            {
                sudokuBoardCell.Clear();
            }
        }
    }
}