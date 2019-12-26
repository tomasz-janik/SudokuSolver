using System;

namespace SudokuSolver.Logger.ConsoleLogger
{
    public class ErrorConsoleLogger : ConsoleAbstractLogger
    {
        public ErrorConsoleLogger(LogLevel mask) : base(mask)
        {
        }
        
        protected override void WriteMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ERROR:");
            base.WriteMessage(msg);
            Console.ResetColor();
        }
    }
}