using System;

namespace SudokuSolver.Logger.ConsoleLogger
{
    internal class ConsoleErrorLogger : ConsoleAbstractLogger
    {
        public ConsoleErrorLogger(LogLevel mask) : base(mask)
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