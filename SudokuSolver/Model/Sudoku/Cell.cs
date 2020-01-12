using System.ComponentModel;

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
                    if (State != State.Restored)
                    {
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("history"));
                    }
                    UserSet(value);
                }
            }
        }

        public State State { get ; set; }
        
        public Cell()
        {
            State = State.Unset;
        }

        public Cell(int value, State state)
        {
            _value = value;
            State = state;
            IndicateChange();
        }

        private void UserSet(int? value)
        {
            State = State.UserSet;
            _value = value;
            IndicateChange();
        }

        public void SolverSet(int value)
        {
            _value = value;
            State = State.SolverSet;
            IndicateChange();
        }

        public void Unset()
        {
            _value = null;
            State = State.Unset;
            IndicateChange();
        }

        public Memento CreateMemento()
        {
            return new Memento(this);
        }

        public void SetMemento(Memento memento)
        {
            memento.Restore();
        }

        private void IndicateChange()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("State"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
        }
    }
}