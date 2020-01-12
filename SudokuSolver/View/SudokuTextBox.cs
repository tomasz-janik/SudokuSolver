using System.Windows.Controls;
using System.Windows.Input;

namespace SudokuSolver.View
{
    public class SudokuTextBox : TextBox
    {
        protected override void OnPreviewTextInput(TextCompositionEventArgs arguments)
        {
            var valid = int.TryParse(arguments.Text, out var result) && result >= 1 && result <= 9;
            arguments.Handled = !valid;

            base.OnPreviewTextInput(arguments);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            e.Handled = (e.Key == Key.Space);

            base.OnKeyDown(e);
        }
    }
}