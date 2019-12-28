using SudokuSolver.Solving.Factory;
using SudokuSolver.Sudoku;

namespace SudokuSolver.Command
{
    public class SolveSudokuCommand : ICommand
    {
        private readonly SudokuBoard _sudokuBoard;
        private readonly ISolvingStrategyFactory _solvingStrategyFactory;
        
        SolveSudokuCommand(SudokuBoard sudokuBoard, ISolvingStrategyFactory solvingStrategyFactory)
        {
            _sudokuBoard = sudokuBoard;
            _solvingStrategyFactory = solvingStrategyFactory;
        }
        
        public void Execute(string strategy)
        {
            _solvingStrategyFactory.GetSolvingStrategy(strategy).Solve(_sudokuBoard.Cells);
        }
    }
}