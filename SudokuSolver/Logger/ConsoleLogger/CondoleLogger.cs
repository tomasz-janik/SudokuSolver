using System;

namespace SudokuSolver.Logger.ConsoleLogger
{
    public class ConsoleAbstractLogger : AbstractLogger
    {
        protected ConsoleAbstractLogger(LogLevel mask) : base(mask)
        {
        }

        protected override void WriteMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}