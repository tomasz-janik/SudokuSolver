namespace SudokuSolver.Logger.Factory
{
    public interface ILoggerFactory
    {
        AbstractLogger GetLogger(LoggerType loggerType);
    }
}