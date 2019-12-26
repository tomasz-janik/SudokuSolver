using System.Collections.Generic;
using SudokuSolver.Logger.ConsoleLogger;

namespace SudokuSolver.Logger.Factory
{
    public class LoggerFactory : ILoggerFactory
    {
        //todo - can be done with reflection (https://code-maze.com/factory-method/) if we want to show we know it - imo stupid af
        private static readonly Dictionary<LoggerType, AbstractLogger> Loggers =
            new Dictionary<LoggerType, AbstractLogger>()
            {
                {LoggerType.ConsoleInfo, new ConsoleInfoLogger(LogLevel.Info)},
                {LoggerType.ConsoleDebug, new ConsoleDebugLogger(LogLevel.Debug)},
                {LoggerType.ConsoleError, new ConsoleErrorLogger(LogLevel.Error)},
                {LoggerType.File, new FileLogger(LogLevel.All)},
            };

        public AbstractLogger GetLogger(LoggerType loggerType)
        {
            return Loggers[loggerType];
        }
    }
}