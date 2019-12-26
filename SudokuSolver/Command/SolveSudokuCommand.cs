using SudokuSolver.Sudoku;

namespace SudokuSolver.Command
{
    public class SolveSudokuCommand : ICommand
    {
        private readonly SudokuBoard _sudokuBoard;
        
        SolveSudokuCommand(SudokuBoard sudokuBoard)
        {
            _sudokuBoard = sudokuBoard;
        }
        
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}