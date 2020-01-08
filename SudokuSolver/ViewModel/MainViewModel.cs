﻿using System;
 using System.ComponentModel;
 using SudokuSolver.Model.Sudoku;
 using SudokuSolver.ViewModel.Command;
 using ICommand = System.Windows.Input.ICommand;

 namespace SudokuSolver.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public string SolvingStrategy { get; set; } = "backtracking";
        public string Filename { get; set; } = "temp";
        public ICommand Command { get; }
        public SudokuBoard SudokuBoard {get; }
        
        public MainViewModel(SudokuBoard sudokuBoard, ICommand command)
        {
            SudokuBoard = sudokuBoard;
            Command = command;
        }
    }

    internal class FactoryCommand : ICommand
    {
        private readonly CommandFactory _commands;

        public FactoryCommand(CommandFactory commands)
        {
            _commands = commands;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var temp = parameter as string;
            _commands.GetCommand(temp).Execute("backtracking");
        }

        public event EventHandler CanExecuteChanged;
    }
}