using SudokuSolver.Digits;

namespace SudokuSolver.Sudoku
{
    public abstract class Cell
    {
        private Digit Digit { get ; set; }
        private State _state;
        
        protected Cell()
        {
            _state = State.Unset;
        }

        protected Cell(Digit digit)
        {
            Digit = digit;
            _state = State.InitialSet;
        }

        public void UserSet(int value)
        {
            Digit.Value = value;
            _state = State.UserSet;            
        }

        public void SolverSet(int value)
        {
            Digit.Value = value;
            _state = State.SolverSet;            
        }
        
        public void Clear()
        {
            Digit.Value = 0;
            _state = State.Unset;
        }
        
    }
}