using System.Collections.Generic;
using System.Xaml;
using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.ViewModel.Parsing
{
    public abstract class Parser<T>
    {
        protected abstract bool ValidateContent(T content);
        protected abstract List<List<Cell>> ParseContent(T content);

        public List<List<Cell>> Parse(T content)
        {
            if (ValidateContent(content))
            {
                return ParseContent(content);
            }
            
            //todo - logger.log
            return new List<List<Cell>>();
        }
    }
}