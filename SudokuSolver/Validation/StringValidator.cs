using System.Linq;

namespace SudokuSolver.Validation
{
    public class StringValidator : IValidator
    {
        private const string Allowed = "123456789. ";

        public bool Validate(string filename)
        {
            return filename.All(c => Allowed.Contains(c));
        }
    }
}