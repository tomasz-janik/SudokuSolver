using SudokuSolver.Model.Logger;

namespace SudokuSolver.Model.Sudoku
{
    public class Memento
    {
        private readonly Cell _state;
        
        private readonly int? _cellValue;

        public Memento(Cell state)
        {
            _state = state;
            _cellValue = state.Value;
            LoggingFacade.Info($"Creating new memento: Value = {state.Value}, State = {state.State}");
        }

        public void Restore()
        {
            _state.State = State.Restored;
            _state.Value = _cellValue;
            LoggingFacade.Info($"Restoring from memento: Value = {_state.Value}");
        }
    }
}