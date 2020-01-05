using SudokuSolver.ViewModel;

namespace SudokuSolver.View
{

    public partial class MainWindow
    {
        internal ViewModelClass ViewModel
        {
            set
            {
                _viewModel = value;
                DataContext = value;
            }
        }
        private ViewModelClass _viewModel;
        
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}