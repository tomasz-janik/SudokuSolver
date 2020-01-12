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
            if (_logger == null)
            {
                _logger = loggers.Pop();
                return;
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

        //todo - ask if this does what i think it does? (is this singleton?) xD
        public static Logger Instance { get; } = new Logger();
    }
}