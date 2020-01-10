using System.ComponentModel;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.View;
using SudokuSolver.ViewModel.Command;
using SudokuSolver.ViewModel.WpfCommand;
using ICommand = System.Windows.Input.ICommand;

namespace SudokuSolver.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string[] SolvingStrategies { get; } = {"backtracking", "pre_solving"};
        public string SolvingStrategy { get; set; } = "backtracking";
        
        public ICommand LoadCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand SolveCommand { get; }

        public SudokuBoard SudokuBoard { get; }

        private readonly CommandFactory _commandFactory;

        public MainViewModel(SudokuBoard sudokuBoard, CommandFactory commandFactory)
        {
            SudokuBoard = sudokuBoard;
            _commandFactory = commandFactory;
            
            ClearCommand = new RelayCommand(e => ClearSudoku());
            LoadCommand = new RelayCommand(e => LoadFile());
            SolveCommand = new RelayCommand(e => SolveSudoku());
        }

        private void LoadFile()
        {
            var fileNames = new OpenFileDialog().ExecuteFileDialog(this, "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|Text Files (*.txt)|*.txt", "*.png");
            if (fileNames != null)
            {
                _commandFactory.GetCommand("load").Execute(fileNames);
            }
        }

        private void ClearSudoku()
        {
            _commandFactory.GetCommand("clear").Execute(null);
        }

        private void SolveSudoku()
        {
            _commandFactory.GetCommand("solve").Execute(SolvingStrategy);
        }
    }
}