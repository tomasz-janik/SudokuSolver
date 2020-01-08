using System.Collections.Generic;
using Ninject;

namespace SudokuSolver.ViewModel.Command
{
    public class CommandFactory : ICommandFactory
    {
        private static readonly Dictionary<string, ICommand> Commands = new Dictionary<string, ICommand>();

        public CommandFactory([Named("clear")] ICommand clear, [Named("solve")] ICommand solve,
            [Named("load")] ICommand load)
        {
            Commands.Add("clear", clear);
            Commands.Add("load", load);
            Commands.Add("solve", solve);
        }

        public ICommand GetCommand(string command)
        {
            return Commands[command];
        }
    }
}