namespace SudokuSolver.Reading
{
    public abstract class Reader<T>
    {
        protected abstract bool ValidateFile(string filename);
        protected abstract T ReadFile(string filename);

        public T Read(string filename)
        {
            if (ValidateFile(filename))
            {
                return ReadFile(filename);
            }
            
            //todo - logger.log
            return default(T);
        }
    }
}