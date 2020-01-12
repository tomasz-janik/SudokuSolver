using System.ComponentModel;
using SudokuSolver.Model.Logger;

namespace SudokuSolver.Model.Sudoku
{
    public class Cell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int? _value;

        public int? Value
        {
            get => _value;
            set
            {
                if (value == null)
                {
                    Unset();
                }
                else
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("history"));
                    UserSet(value);
                }
            }
        }

        public State State { get ; set; }
        
        public Cell()
        {
            State = State.Unset;
        }

        public Cell(int? value, State state)
        {
            _value = value;
            State = state;
            IndicateChange();
            LoggingFacade.Info($"Initializing cell with Value = {value}, State = {state}");
        }

        private void UserSet(int? value)
        {
            State = State.UserSet;
            _value = value;
            IndicateChange();
            LoggingFacade.Info($"User changed cell value to {value}");
        }

        public void SolverSet(int value)
        {
            _value = value;
            State = State.SolverSet;
            IndicateChange();
            LoggingFacade.Info($"Solver changed cell value to {value}");
        }

        public void Unset()
        {
            _value = null;
            State = State.Unset;
            IndicateChange();
            LoggingFacade.Info($"Clearing cell");
        }

        public Memento CreateMemento()
        {
            return new Memento(this);
        }

        private void IndicateChange()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("State"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
        }
    }
}