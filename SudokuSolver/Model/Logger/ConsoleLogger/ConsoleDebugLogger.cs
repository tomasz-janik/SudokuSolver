using System;

namespace SudokuSolver.Model.Logger.ConsoleLogger
{
    internal class ConsoleDebugLogger : ConsoleAbstractLogger
    {
        public ConsoleDebugLogger(LogLevel mask) : base(mask)
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