namespace SudokuSolver.ViewModel.Validation
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
            return true;
        }
    }
}