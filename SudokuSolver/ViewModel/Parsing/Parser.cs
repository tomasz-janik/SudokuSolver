using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.ViewModel.Parsing
{
    public abstract class Parser<T>
    {
        protected abstract bool ValidateContent(T content);
        protected abstract Cell[,] ParseContent(T content);

        public Cell[,] Parse(T content)
        {
            if (ValidateContent(content))
            {
                return ParseContent(content);
            }
            
            //todo - logger.log
            return new Cell[9,9];
        }
    }
}