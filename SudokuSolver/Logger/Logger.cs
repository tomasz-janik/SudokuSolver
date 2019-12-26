namespace SudokuSolver.Logger
{
    public sealed class Logger
    {
        private AbstractLogger _logger;

        private Logger()
        {
        }

        public void AddLogger(AbstractLogger logger)
        {
            if (_logger == null)
            {
                _logger = logger;
                return;
            }
            _logger.SetNext(logger);
        }
        
        public void Message(string message, LogLevel severity)
        {
            _logger.Message(message, severity);
        }
        
        //todo - ask if this does what i think it does? (is this singleton?) xD
        public static Logger Instance { get; } = new Logger();
    }
}