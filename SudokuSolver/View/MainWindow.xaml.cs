using SudokuSolver.ViewModel;

namespace SudokuSolver.View
{
    public partial class MainWindow
    {
        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
        }
    }
}