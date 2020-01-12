using System;
using System.IO;

namespace SudokuSolver.Model.Logger
{
    internal class FileLogger : AbstractLogger
    {
        public string Filepath;

        public FileLogger(LogLevel mask, string filepath = "logs.txt") : base(mask)
        {
            Filepath = filepath;
        }

        protected override void WriteMessage(string message)
        {
            using var writer = File.AppendText(Filepath);
            writer.WriteLine($"{DateTime.Now.ToShortTimeString()} : {message}");
        }
    }
}