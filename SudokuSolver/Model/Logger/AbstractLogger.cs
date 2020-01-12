namespace SudokuSolver.Model.Logger
{
    public abstract class AbstractLogger
    {
        private readonly LogLevel _logMask;
        private AbstractLogger _next;

        protected AbstractLogger(LogLevel mask)
        {
            this._logMask = mask;
        }

        public AbstractLogger SetNext(AbstractLogger abstractLogger)
        {
            var lastLogger = this;

            while (lastLogger._next != null)
            {
                lastLogger = lastLogger._next;
            }

            lastLogger._next = abstractLogger;
            return this;
        }

        public void Message(string msg, LogLevel severity)
        {
            if ((severity & _logMask) != 0)
            {
                WriteMessage(msg);
            }

            _next?.Message(msg, severity);
        }

        protected abstract void WriteMessage(string msg);
    }
}