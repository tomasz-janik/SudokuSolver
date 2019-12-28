namespace SudokuSolver.Sudoku
{
    //todo - can this be Originator in Memento pattern? - imo yes
    public class SudokuBoard
    {
        public Cell[,] Cells { get; set; }

        public Memento CreateMemento(int row, int column)
        {
            return new Memento(Cells[row, column], row, column);
        }

        public void SetMemento(Memento memento)
        {
            Cells[memento.Row, memento.Column] = memento.State;
        }
    }
}