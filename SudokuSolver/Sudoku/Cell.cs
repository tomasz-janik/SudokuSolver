using SudokuSolver.Digits;

namespace SudokuSolver.Sudoku
{
    public abstract class Cell
    {
        private Digit Digit { get ; set; }
        private State State;
        
        public int Row { get; set; }

        public int Column { get; set; }

        protected Cell()
        {
            
        }

        protected Cell(Digit digit)
        {
            Digit = digit;
        }

        public void UserSet(int value)
        {
            Digit.Value = value;
            State = State.UserSet;            
        }

        public void SolverSet(int value)
        {
            Digit.Value = value;
            State = State.SolverSet;            
        }
        
        public void Clear()
        {
            Digit.Value = 0;
            State = State.Unset;
        }
        
    }
}