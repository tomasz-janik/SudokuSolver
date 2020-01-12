using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver.Model.Logger.Factory
{
    public class FileLoggerFactory : ILoggerFactory
    {
        private static readonly Dictionary<LoggerType, AbstractLogger> Loggers =
            new Dictionary<LoggerType, AbstractLogger>
            {
                {LoggerType.File, new FileLogger(LogLevel.All)}
            };

        public List<AbstractLogger> GetLoggers()
        {
            return Loggers.Select(pair => pair.Value).ToList();
        }

        public AbstractLogger GetLogger(LoggerType loggerType)
        {
            return Loggers[loggerType];
        }
    }
}