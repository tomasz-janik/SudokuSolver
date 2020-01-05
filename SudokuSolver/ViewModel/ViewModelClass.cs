﻿using System.ComponentModel;
 using System.Runtime.CompilerServices;

 namespace SudokuSolver.ViewModel
{
    public sealed class ViewModelClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private static ViewModelClass _instance;


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static ViewModelClass GetInstance(MainWindow window)
        {
            return _instance ??= new ViewModelClass();
        }
    }
}