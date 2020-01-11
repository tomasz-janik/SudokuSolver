using System.Windows;
using SudokuSolver.ViewModel.DialogWindow;

namespace SudokuSolver.View
{
    public class MessageDialog : IMessageDialogWindow
    {
        public void ExecuteMessageDialog(string text)
        {
            MessageBox.Show(text);
        }
    }
}