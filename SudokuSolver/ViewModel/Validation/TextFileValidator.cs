using SudokuSolver.Model.Logger;

namespace SudokuSolver.ViewModel.Validation
{
    public class TextFileValidator : IValidator
    {
        public bool Validate(string filename)
        {
            if (!filename.EndsWith(".txt"))
            {
                LoggingFacade.Error($"Filename {filename} doesn't end with .txt");
                return false;
            }
            
            LoggingFacade.Info($"Filename {filename} is valid");
            return true;
        }
    }
}