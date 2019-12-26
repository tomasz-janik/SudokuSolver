namespace SudokuSolver.Digits
{
    public class Digit : IDigit
    {
        public int Value { get; set; }

        public Digit(int value)
        {
            Value = value;
        }
        
        public string Display()
        {
            return $"Digit {Value}\n\r";
        }

    }
}