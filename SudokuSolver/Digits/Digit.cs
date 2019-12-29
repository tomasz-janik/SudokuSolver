namespace SudokuSolver.Digits
{
    public class Digit : IDigit
    {
        public int Value { get; set; }

        public Digit(int value)
        {
            Value = value;
        }
        
        public static bool operator ==(Digit b1, Digit b2)
        {
            if ((object)b1 == null)
                return (object)b2 == null;

            return b1.Equals(b2);
        }

        public static bool operator !=(Digit b1, Digit b2)
        {
            return !(b1 == b2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Digit) obj);
        }

        private bool Equals(Digit other)
        {
            return Value == other.Value;
        }
        
        public override int GetHashCode()
        {
            return Value;
        }
        
        public string Display()
        {
            return $"Digit {Value}\n\r";
        }

    }
}