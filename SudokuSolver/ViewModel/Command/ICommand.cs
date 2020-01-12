namespace SudokuSolver.ViewModel.Command
{
    public interface ICommand
    {
        bool Execute(string parameter);
    }
}