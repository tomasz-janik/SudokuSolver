using System.Windows;

namespace SudokuSolver.ViewModel.DialogWindow
{
    public interface IMessageDialogWindow
    {
        public void ExecuteMessageDialog(string text);
    }
}