using System;
using SudokuSolver.Model.Logger.Factory;

namespace SudokuSolver.Model.Logger
{
    public static class LoggingFacade
    {
        //todo - any way to make it prettier?
        private static readonly Logger Logger = Logger.Instance;
        private static readonly LoggerFactoryProvider LoggerFactoryProvider = new LoggerFactoryProvider();

        static LoggingFacade()
        {
            Init();
        }

        private static void Init()
        {
            foreach (LoggerFactoryType loggerFactoryType in Enum.GetValues(typeof(LoggerFactoryType)))
            {
                var loggingFactory = LoggerFactoryProvider.GetFactory(loggerFactoryType);
                Logger.AddLoggers(loggingFactory.GetLoggers());
            }
        }

        public static void Info<T>(T message)
        {
            Logger.Message(message.ToString(), LogLevel.Info);
        }

        public static void Debug<T>(T message)
        {
            Logger.Message(message.ToString(), LogLevel.Debug);
        }

        public static void Warning<T>(T message)
        {
            Logger.Message(message.ToString(), LogLevel.Warning);
        }

        public static void Error<T>(T message)
        {
            Logger.Message(message.ToString(), LogLevel.Error);
        }

        //todo - check if this will change filepath xD (it will, i'm just not thinking anymore, so not sure)
        public static void SetLogFile(string filename)
        {
            var logger = (FileLogger) LoggerFactoryProvider.GetFactory(LoggerFactoryType.File)
                .GetLogger(LoggerType.File);
            logger.Filepath = filename;
        }
    }
}