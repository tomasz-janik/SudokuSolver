namespace SudokuSolver.ViewModel.DialogWindow
{
    public interface IFileDialogWindow
    {
        string ExecuteFileDialog(object owner, string filter, string defaultExt);
    }
}