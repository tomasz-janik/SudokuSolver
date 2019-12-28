namespace SudokuSolver.Sudoku
{
    public class Memento
    {
        public Cell State { get; }
        public int Row { get; }
        public int Column { get; }

        public Memento(Cell state, int row, int column)
        {
            State = state;
            Row = row;
            Column = column;
        }
    }
}