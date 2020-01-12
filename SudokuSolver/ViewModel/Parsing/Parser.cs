using System.Collections.Generic;
using SudokuSolver.Model.Logger;
using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.ViewModel.Parsing
{
    public abstract class Parser<T>
    {
        protected abstract bool ValidateContent(T content);
        protected abstract List<List<Cell>> ParseContent(T content);

        public List<List<Cell>> Parse(T content)
        {
            LoggingFacade.Info("Parsing input");
            if (ValidateContent(content))
            {
                return ParseContent(content);
            }

            LoggingFacade.Error($"Couldn't parse given input = {content}");
            return default;
        }
    }
}