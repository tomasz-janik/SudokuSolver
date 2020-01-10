using System.Windows;
using System.Windows.Input;
using SudokuSolver.ViewModel;

namespace SudokuSolver.View
{
    public partial class MainWindow
    {
        private readonly MainViewModel _mainViewModel; 
        public MainWindow(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            InitializeComponent();
            DataContext = _mainViewModel;
        }

        private void Cell_OnPreviewTextInput(object sender, TextCompositionEventArgs arguments)
        {
            var valid = int.TryParse(arguments.Text, out var result) && result >= 1 && result <= 9;
            arguments.Handled = !valid;
        }
        
        private void Cell_OnKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = (e.Key == Key.Space);
        }
    }
}