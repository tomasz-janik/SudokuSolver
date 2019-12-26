using System;

namespace SudokuSolver.Logger.ConsoleLogger
{
    public class DebugConsoleLogger : ConsoleAbstractLogger
    {
        public DebugConsoleLogger(LogLevel mask) : base(mask)
        {
        }
        
        protected override void WriteMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("DEBUG:");
            base.WriteMessage(msg);
            Console.ResetColor();
        }
    }
}