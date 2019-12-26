namespace SudokuSolver.Logger
{
    class FileLogger : AbstractLogger
    {
        public FileLogger(LogLevel mask) : base(mask)
        {
        }

        protected override void WriteMessage(string msg)
        {
            //todo - implement logging to file
            throw new System.NotImplementedException();
        }
    }
}