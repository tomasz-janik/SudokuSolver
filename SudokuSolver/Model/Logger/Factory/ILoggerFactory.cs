using System.Collections.Generic;

namespace SudokuSolver.Model.Logger.Factory
{
    public interface ILoggerFactory
    {
        List<AbstractLogger> GetLoggers();

        AbstractLogger GetLogger(LoggerType loggerType);
    }
}