using System;
using SudokuSolver.Logger.Factory;

namespace SudokuSolver.Logger
{
    public class LoggingFacade
    {
        private Logger _logger;
        private readonly LoggerFactory _loggerFactory;

        public LoggingFacade(LoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Init()
        { 
            _logger = Logger.Instance;
            foreach (LoggerType loggerType in Enum.GetValues(typeof(LoggerType)))
            {
                _logger.AddLogger(_loggerFactory.GetLogger(loggerType));
            }
        }

        public void Info<T>(T message)
        {
            _logger.Message(message.ToString(), LogLevel.Info);
        }
        
        public void Debug<T>(T message)
        {
            _logger.Message(message.ToString(), LogLevel.Debug);
        }

        public void Warning<T>(T message)
        {
            _logger.Message(message.ToString(), LogLevel.Warning);
        }
        
        public void Error<T>(T message)
        {
            _logger.Message(message.ToString(), LogLevel.Error);
        }
        
        //todo - check if this will change filepath xD (it will, i'm just not thinking anymore, so not sure)
        public void SetLogFile(string filename)
        {
            var logger = (FileLogger) _loggerFactory.GetLogger(LoggerType.File);
            logger.Filepath = filename;
        }
    }
}