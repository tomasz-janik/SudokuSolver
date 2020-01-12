namespace SudokuSolver.ViewModel.Command
{
    public interface ICommandFactory
    {
        ICommand GetCommand(string command);
    }
}