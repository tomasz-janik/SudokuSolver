using SudokuSolver.Model.Logger;

namespace SudokuSolver.ViewModel.Reading
{
    public abstract class Reader<T>
    {
        protected abstract bool ValidateFile(string filename);
        protected abstract T ReadFile(string filename);

        public T Read(string filename)
        {
            LoggingFacade.Info("Reading from file");
            if (ValidateFile(filename))
            {
                return ReadFile(filename);
            }
            
            LoggingFacade.Error($"Failed to read from file = {filename}");
            return default;
        }
    }
}