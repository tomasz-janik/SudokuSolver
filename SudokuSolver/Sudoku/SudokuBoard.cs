namespace SudokuSolver.Sudoku
{
    public class SudokuBoard
    {
        private Cell[,] _cells;

        public Cell[,] Cells
        {
            get => _cells;
            set => _cells = value;
        }
    }
}