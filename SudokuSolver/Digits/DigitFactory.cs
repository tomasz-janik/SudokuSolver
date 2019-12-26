using System.Collections.Generic;

namespace SudokuSolver.Digits
{
    public class DigitFactory
    {
        private readonly Dictionary<int, Digit> _digits = new Dictionary<int, Digit>();

        public Digit this[int key]
        {
            get
            {
                if (_digits.TryGetValue(key, out var digit)) return digit;
                
                _digits.Add(key, new Digit(key));
                _digits[key].Value = key;
                return _digits[key];
            }
            set => _digits[key] = value;
        }
    }
}