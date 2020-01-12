using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Model.Logger.ConsoleLogger;

namespace SudokuSolver.Model.Logger.Factory
{
    public class ConsoleLoggerFactory : ILoggerFactory
    {
        private readonly Dictionary<LoggerType, AbstractLogger> _loggers =
            new Dictionary<LoggerType, AbstractLogger>
            {
                {LoggerType.ConsoleInfo, new ConsoleInfoLogger(LogLevel.Info)},
                {LoggerType.ConsoleDebug, new ConsoleDebugLogger(LogLevel.Debug)},
                {LoggerType.ConsoleError, new ConsoleErrorLogger(LogLevel.Error)}
            };

        public List<AbstractLogger> GetLoggers()
        {
            return _loggers.Select(pair => pair.Value).ToList();
        }

        public AbstractLogger GetLogger(LoggerType loggerType)
        {
            return _loggers[loggerType];
        }
    }
}