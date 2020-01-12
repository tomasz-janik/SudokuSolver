using SudokuSolver.Model.Logger;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.ViewModel.Solving.Factory;

namespace SudokuSolver.ViewModel.Command
{
    public class SolveSudokuCommand : ICommand
    {
        private readonly SudokuBoard _sudokuBoard;
        private readonly ISolvingStrategyFactory _solvingStrategyFactory;

        public SolveSudokuCommand(SudokuBoard sudokuBoard, ISolvingStrategyFactory solvingStrategyFactory)
        {
            _sudokuBoard = sudokuBoard;
            _solvingStrategyFactory = solvingStrategyFactory;
        }

        public bool Execute(string strategy)
        {
            LoggingFacade.Info($"Solving sudoku with strategy = {strategy}");
            if (_solvingStrategyFactory.GetSolvingStrategy(strategy).Solve(_sudokuBoard.Cells))
            {
                _sudokuBoard.ClearHistory();
                LoggingFacade.Info("Solved sudoku");
                return true;
            }

            LoggingFacade.Error("Couldn't solve sudoku");
            return false;
        }
    }
}