using System.Windows;
using SudokuSolver.ViewModel;

namespace SudokuSolver.View
{

    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}