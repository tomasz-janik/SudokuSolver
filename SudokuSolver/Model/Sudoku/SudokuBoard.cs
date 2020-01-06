using System.Collections.Generic;
using System.ComponentModel;
using SudokuSolver.Model.Digits;

namespace SudokuSolver.Model.Sudoku
{
    //todo - can this be Originator in Memento pattern? - imo yes
    public class SudokuBoard : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        public List<List<Cell>> Cells {get; set;}
        
        public SudokuBoard(int width, int height)
        {
            Cells = new List<List<Cell>>(width);
            for (var i = 0; i < width; i++)
            {
                var row = new List<Cell>(height);
                for (var j = 0; j < height; j++)
                {
                    row.Add(new Cell());
                }
                Cells.Add(row);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SudokuBoard"));
            }
        }

        public Memento CreateMemento(int row, int column)
        {
            return null; //new Memento(Cells[row][column], row, column);
        }

        public void SetMemento(Memento memento)
        {
            //Cells[memento.Row][memento.Column] = memento.State;
        }
    }
}