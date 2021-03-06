﻿using System.ComponentModel;
using System.Threading.Tasks;
using SudokuSolver.Model.Logger;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.View;
using SudokuSolver.ViewModel.Command;
using ICommand = System.Windows.Input.ICommand;

namespace SudokuSolver.ViewModel
{
    //todo - should this class be refactored?
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string[] SolvingStrategies { get; } = {"backtracking", "pre_solving"};
        public string SolvingStrategy { get; set; } = "backtracking";

        public ICommand LoadCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand SolveCommand { get; }
        public ICommand UndoCommand { get; }

        public SudokuBoard SudokuBoard { get; }

        private readonly CommandFactory _commandFactory;

        public MainViewModel(SudokuBoard sudokuBoard, CommandFactory commandFactory)
        {
            SudokuBoard = sudokuBoard;
            SudokuBoard.CreateDefaultSudoku();
            _commandFactory = commandFactory;

            ClearCommand = new RelayCommand(e => ClearSudoku());
            LoadCommand = new RelayCommand(e => LoadFile());
            SolveCommand = new RelayCommand(e => SolveSudoku());
            UndoCommand = new RelayCommand(e => UndoSudoku());
        }

        private void LoadFile()
        {
            var fileNames = new OpenFileDialog().ExecuteFileDialog(this,
                "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|Text Files (*.txt)|*.txt", "*.png");
            if (fileNames == null) return;

            _commandFactory.GetCommand("clear").Execute(null);
            _commandFactory.GetCommand("load").Execute(fileNames);
        }

        private async void ClearSudoku()
        {
            await Task.Run(() =>
            {
                _commandFactory.GetCommand("clear").Execute(null);
            });
        }

        private async void SolveSudoku()
        {
            await Task.Run(() =>
            {
                if (_commandFactory.GetCommand("solve").Execute(SolvingStrategy)) return;

                //todo - we can localize it e.g. polish, english if there is sth for it in c#
                LoggingFacade.Error("Couldn't solve sudoku");
                new MessageDialog().ExecuteMessageDialog("Sudoku is not solvable");
            });
        }

        private async void UndoSudoku()
        {
            await Task.Run(() =>
            {
                if (_commandFactory.GetCommand("undo").Execute(null)) return;

                //todo - we can localize it e.g. polish, english if there is sth for it in c#
                LoggingFacade.Error("Couldn't undo move");
                new MessageDialog().ExecuteMessageDialog("Undo impossible"); 
            });
        }
    }
}