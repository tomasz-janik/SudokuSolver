using System;

namespace SudokuSolver.Logger.ConsoleLogger
{
    public class InfoConsoleLogger : ConsoleAbstractLogger
    {
        public InfoConsoleLogger(LogLevel mask) : base(mask)
        {
        }
        
        protected override void WriteMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("INFO:");
            base.WriteMessage(msg);
            Console.ResetColor();
        }
    }
}