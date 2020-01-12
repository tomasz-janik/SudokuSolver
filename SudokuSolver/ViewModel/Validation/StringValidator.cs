using System.Linq;
using SudokuSolver.Model.Logger;

namespace SudokuSolver.ViewModel.Validation
{
    public class StringValidator : IValidator
    {
        private const string Allowed = "123456789. ";

        public bool Validate(string content)
        {
            LoggingFacade.Info($"Validating content = {content}");
            return ValidateLength(content) && ValidateCharacters(content);
        }

        private static bool ValidateLength(string content)
        {
            if (content.Length == 81)
            {
                LoggingFacade.Info("Input length is valid");
                return true;
            }

            LoggingFacade.Error($"Input length isn't valid = {content.Length}");
            return false;
        }

        private static bool ValidateCharacters(string content)
        {
            if (content.All(letter => Allowed.Contains(letter)))
            {
                LoggingFacade.Info("Input contains only valid characters");
                return true;
            }

            LoggingFacade.Error("Input contains illegal characters");
            return false;
        }
    }
}