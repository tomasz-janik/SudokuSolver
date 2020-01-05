using System.Windows;
using SudokuSolver.ViewModel;

namespace SudokuSolver
{

    public partial class MainWindow : Window
    {
        private ViewModelClass _viewModel;
        public MainWindow()
        {
            InitializeComponent();
        }
        
        internal ViewModelClass ViewModel
        {
            set
            {
                _viewModel = value;
                DataContext = value;
            }
        }
    }
}