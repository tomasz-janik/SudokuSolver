using System.Collections.Generic;
using SudokuSolver.Sudoku;

namespace SudokuSolver.Parsing
{
    public abstract class Parser<T>
    {
        protected abstract bool ValidateContent(T content);
        protected abstract List<Cell> ParseContent(T content);

        public List<Cell> Parse(T content)
        {
            if (ValidateContent(content))
            {
                return ParseContent(content);
            }
            
            //todo - logger.log
            return new List<Cell>();
        }
    }
}