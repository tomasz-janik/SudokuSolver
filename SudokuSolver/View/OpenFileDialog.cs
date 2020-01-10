using System.Windows;
using SudokuSolver.ViewModel;

namespace SudokuSolver.View
{
    public class OpenFileDialog : IDialogWindow
    {
        public string ExecuteFileDialog(object owner, string filter, string defaultExt)
        {
            var fileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = filter,
                DefaultExt = defaultExt
            };
            
            return fileDialog.ShowDialog(owner as Window) == true ? fileDialog.FileName : null;
        }
    }
}