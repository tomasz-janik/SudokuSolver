namespace SudokuSolver.Validation
{
    public class TextFileValidator : IValidator
    {
        public bool Validate(string filename)
        {
            if (!filename.EndsWith(".txt"))
            {
                //log
                return false;
            }
            if (!filename.EndsWith(".json"))
            {
                //log
                return false;
            }
            return true;
        }
    }
}