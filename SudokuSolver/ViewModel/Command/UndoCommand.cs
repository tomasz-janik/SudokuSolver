using SudokuSolver.Model.Logger;
using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.ViewModel.Command
{
    public class UndoCommand : ICommand
    {
        private readonly History _history;

        public UndoCommand(History history)
        {
            _history = history;
        }

        public bool Execute(string _)
        {
            LoggingFacade.Info("Undoing previous move");
            if (!_history.IsUndoPossible())
            {
                LoggingFacade.Error("Couldn't undo move");
                return false;
            }

            LoggingFacade.Info("Undone move");
            _history.GetUndoMemento().Restore();
            return true;
        }
    }
}