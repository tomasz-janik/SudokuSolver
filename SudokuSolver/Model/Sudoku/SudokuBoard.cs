using System.Collections.Generic;
using System.ComponentModel;

namespace SudokuSolver.Model.Sudoku
{
    //todo - can this be Originator in Memento pattern? - imo yes
    //todo - should it be in model or viewmodel?
    public class SudokuBoard : INotifyPropertyChanged
    {
        private readonly History _history;
        public event PropertyChangedEventHandler PropertyChanged;
        public List<List<Cell>> Cells { get; set; }

        public SudokuBoard(History history)
        {
            _history = history;
        }

        public void CreateDefaultSudoku()
        {
            Cells = new List<List<Cell>>(9);
            for (var i = 0; i < 9; i++)
            {
                var row = new List<Cell>(9);
                for (var j = 0; j < 9; j++)
                {
                    var cell = new Cell();
                    cell.PropertyChanged += ChildChanged;
                    row.Add(cell);
                }

                Cells.Add(row);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cells"));
            }
        }
        
        private void ChildChanged(object sender, PropertyChangedEventArgs arguments)
        {
            var child = sender as Cell;
            if (arguments.PropertyName != "history") return;
            if (child?.State == State.Restored) return;

            _history.AddUndoMemento(child?.CreateMemento());
        }
        
        public void ClearHistory()
        {
            _history.Clear();
        }

        public void LoadSudoku(List<List<Cell>> result)
        {
            Cells = result;
            ClearHistory();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cells"));
        }
    }
}