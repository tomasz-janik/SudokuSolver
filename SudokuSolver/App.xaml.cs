using System.Windows;
using SudokuSolver.ViewModel;

namespace SudokuSolver
{
    public partial class App : Application
    {
        public void ApplicationStartup(object sender, StartupEventArgs args)
        {
            var mainWindow = new MainWindow(); 
            mainWindow.ViewModel = ViewModelClass.GetInstance(mainWindow);
            mainWindow.Show();
        }
    }
}