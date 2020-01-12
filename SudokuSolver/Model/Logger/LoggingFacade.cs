using System;
using SudokuSolver.Model.Logger.Factory;

namespace SudokuSolver.Model.Logger
{
    public class LoggingFacade
    {
        private static Logger _logger;
        private readonly LoggerFactoryProvider _loggerFactoryProvider;

        public LoggingFacade(LoggerFactoryProvider loggerFactoryProvider)
        {
            _loggerFactoryProvider = loggerFactoryProvider;
            Init();
        }

        private void Init()
        {
            _logger = Logger.Instance;
            foreach (LoggerFactoryType loggerFactoryType in Enum.GetValues(typeof(LoggerFactoryType)))
            {
                var loggingFactory = _loggerFactoryProvider.GetFactory(loggerFactoryType);
                _logger.AddLoggers(loggingFactory.GetLoggers());
            }
        }

        public static void Info<T>(T message)
        {
            _logger.Message(message.ToString(), LogLevel.Info);
        }

        public static void Debug<T>(T message)
        {
            _logger.Message(message.ToString(), LogLevel.Debug);
        }

        public static void Warning<T>(T message)
        {
            _logger.Message(message.ToString(), LogLevel.Warning);
        }

        public static void Error<T>(T message)
        {
            _logger.Message(message.ToString(), LogLevel.Error);
        }

        //todo - check if this will change filepath xD (it will, i'm just not thinking anymore, so not sure)
        public void SetLogFile(string filename)
        {
            var logger = (FileLogger) _loggerFactoryProvider.GetFactory(LoggerFactoryType.File)
                .GetLogger(LoggerType.File);
            logger.Filepath = filename;
        }
    }
}