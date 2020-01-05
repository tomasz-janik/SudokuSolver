using System.Collections.Generic;
using SudokuSolver.Utils;

namespace SudokuSolver.Model.Sudoku
{
    //todo - can this be Originator in Memento pattern? - imo yes
    public class SudokuBoard
    {
        public Cell[,] Cells { get; set; }

        public SudokuBoard()
        {
            Cells = new Cell[9,9];
        }

        public SudokuBoard(Cell[,] cells)
        {
            Cells = cells;
        }

        public SudokuBoard(IEnumerable<Cell> cells)
        {
            Cells = cells.ToGroup(9).ToRectangularArray(9);
        }
        
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