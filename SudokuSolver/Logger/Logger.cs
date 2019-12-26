using SudokuSolver.Logger.ConsoleLogger;

namespace SudokuSolver.Logger
{
    public sealed class Logger
    {
        private AbstractLogger _logger;
        private Logger()
        {
            //todo - can chain of responsibility work like that (even if it's handled go to next one) or should we change it?
            _logger = new InfoConsoleLogger(LogLevel.Info)
                .SetNext(new DebugConsoleLogger(LogLevel.Debug))
                .SetNext(new ErrorConsoleLogger(LogLevel.Warning | LogLevel.Error))
                .SetNext(new FileLogger(LogLevel.All));
        }

        //todo - ask if this does what i think it does? xD
        public static Logger Instance { get; } = new Logger();
    }
}