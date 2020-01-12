using System.Collections.Generic;

namespace SudokuSolver.Model.Logger.Factory
{
    public abstract class LoggerFactoryProvider
    {
        private readonly Dictionary<LoggerFactoryType, ILoggerFactory> _factories =
            new Dictionary<LoggerFactoryType, ILoggerFactory>()
            {
                {LoggerFactoryType.Console, new ConsoleLoggerFactory()},
                {LoggerFactoryType.File, new FileLoggerFactory()}
            };

        public ILoggerFactory GetFactory(LoggerFactoryType loggerFactoryType)
        {
            return _factories[loggerFactoryType];
        }
    }
}