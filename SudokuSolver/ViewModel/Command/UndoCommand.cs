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
            if (!_history.IsUndoPossible()) return false;
            
            _history.GetUndoMemento().Restore();
            return true;

        }
    }
}