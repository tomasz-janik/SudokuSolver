﻿using System.ComponentModel;
 using SudokuSolver.Model.Sudoku;

 namespace SudokuSolver.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public SudokuBoard SudokuBoard {get; } = new SudokuBoard(9, 9);
    }

}