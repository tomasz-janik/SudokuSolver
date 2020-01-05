using System.Linq;

namespace SudokuSolver.Validation
{
    public class StringValidator : IValidator
    {
        private const string Allowed = "123456789. ";

        public bool Validate(string filename)
        {
            return ValidateLength(filename) && ValidateCharacters(filename);
        }

        private static bool ValidateLength(string filename)
        {
            return filename.Length == 81;
        }

        private static bool ValidateCharacters(string filename)
        {
            return filename.All(letter => Allowed.Contains(letter));
        }
    }
}