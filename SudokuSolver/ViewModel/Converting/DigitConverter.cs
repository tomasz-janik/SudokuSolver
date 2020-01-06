using System;
using System.Globalization;
using System.Windows.Data;
using SudokuSolver.Model.Digits;

namespace SudokuSolver.ViewModel.Converting
{
    public class DigitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = value is Digit digit ? digit : Digit.Empty();
            return status.Value != 0 ? status.Value.ToString() : "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = value is string str ? str : "";
            int.TryParse(status, out var output);
            return output;
        }
    }
}