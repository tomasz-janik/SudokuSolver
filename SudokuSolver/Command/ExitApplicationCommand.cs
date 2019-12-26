using System.Windows;

namespace SudokuSolver.Command
{
    public class ExitApplicationCommand : ICommand
    {
        private readonly Window _window;

        public ExitApplicationCommand(Window window)
        {
            _window = window;
        }

        public void Execute()
        {
            _window.Close();
        }
    }
}