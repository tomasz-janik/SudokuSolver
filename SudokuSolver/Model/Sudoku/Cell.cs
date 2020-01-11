using System.ComponentModel;
using SudokuSolver.Model.Digits;

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
                _value = value;
                State = value == null ? State.Unset : State.UserSet;
                IndicateChange();
            }
        }

        public State State { get ; private set; }
        
        public Cell()
        {
            State = State.Unset;
        }
        
        public Cell(int value, State state)
        {
            Value = value;
            State = state;
            IndicateChange();
        }

        public void UserSet(int value)
        {
            Value = value;
            State = State.UserSet; 
            IndicateChange();
        }

        public void SolverSet(int value)
        {
            Value = value;
            State = State.SolverSet;
            IndicateChange();
        }

        public void Unset()
        {
            Value = null;
            State = State.Unset;
            IndicateChange();
        }

        private void IndicateChange()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("State"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
        }
        
    }
}