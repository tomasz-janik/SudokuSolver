using System;
using System.Globalization;
using System.Windows.Data;

namespace SudokuSolver.ViewModel.Converting
{
    public class DigitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (int.TryParse(value as string, out var result)) return result;
            return null;
        }
    }
}