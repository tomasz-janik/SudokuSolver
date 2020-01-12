using System.Collections.Generic;

namespace SudokuSolver.Model.Digits
{
    public class DigitFactory
    {
        public readonly Digit Default = new Digit(0); 
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
        }
    }
}