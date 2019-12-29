using SudokuSolver.Digits;

namespace SudokuSolver.Sudoku
{
    public abstract class Cell
    {
        public Digit Digit { get ; set; }
        public State State;
        
        protected Cell()
        {
            State = State.Unset;
        }

        protected Cell(Digit digit)
        {
            Digit = digit;
            State = State.InitialSet;
        }

        public void UserSet(int value)
        {
            Digit.Value = value;
            State = State.UserSet;            
        }

        public void SolverSet(Digit digit)
        {
            Digit = digit;
            State = State.SolverSet;            
        }

        public void Unset()
        {
            Digit = null;
            State = State.Unset;            
        }
        
        public void Clear()
        {
            Digit.Value = 0;
            State = State.Unset;
        }
        
    }
}