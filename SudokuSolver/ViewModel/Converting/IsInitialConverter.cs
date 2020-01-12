using System;
using System.Globalization;
using System.Windows.Data;
using SudokuSolver.Model;

namespace SudokuSolver.ViewModel.Converting
{
    public class IsInitialConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = value is State state ? state : State.Unset;
            return status == State.InitialSet;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = value is State state ? state : State.Unset;
            return status;
        }
    }
}