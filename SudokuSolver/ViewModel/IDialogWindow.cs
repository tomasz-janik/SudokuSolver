namespace SudokuSolver.ViewModel
{
    public interface IDialogWindow
    {
        string ExecuteFileDialog(object owner, string filter, string defaultExt);
    }
}