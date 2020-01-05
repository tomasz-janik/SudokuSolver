namespace SudokuSolver.ViewModel.Command
{
    //todo - should be replaced with ICommand from c#
    public interface ICommand
    {
        void Execute(string parameter);
    }
}