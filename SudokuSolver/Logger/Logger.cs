using SudokuSolver.Logger.ConsoleLogger;

namespace SudokuSolver.Logger
{
    public sealed class Logger
    {
        private AbstractLogger _logger;
        private Logger()
        {
            //todo - should be inverted or it doesnt matter - check how to properly implement (from higher to lower, or otherwise)
            _logger = new InfoConsoleLogger(LogLevel.Info)
                .SetNext(new DebugConsoleLogger(LogLevel.Debug))
                .SetNext(new ErrorConsoleLogger(LogLevel.Warning | LogLevel.Error))
                .SetNext(new FileLogger(LogLevel.All));
        }

        //todo - ask if this does what i think it does? xD
        public static Logger Instance { get; } = new Logger();
    }
}