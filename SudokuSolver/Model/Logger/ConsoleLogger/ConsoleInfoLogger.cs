using System;

namespace SudokuSolver.Model.Logger.ConsoleLogger
{
    internal class ConsoleInfoLogger : ConsoleAbstractLogger
    {
        public ConsoleInfoLogger(LogLevel mask) : base(mask)
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