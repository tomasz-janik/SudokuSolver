using System.Collections.Generic;
using SudokuSolver.Utils;

namespace SudokuSolver.Model.Logger
{
    public sealed class Logger
    {
        private AbstractLogger _logger;

        private Logger()
        {
        }
        
        public void AddLoggers(List<AbstractLogger> loggers)
        {
            if (loggers.Count == 0) return;
            if (_logger == null)
            {
                _logger = loggers.Pop();
            }

            foreach (var logger in loggers)
            {
                _logger.SetNext(logger);
            }
        }

        public void Message(string message, LogLevel severity)
        {
            _logger.Message(message, severity);
        }

        public static Logger Instance { get; } = new Logger();
    }
}