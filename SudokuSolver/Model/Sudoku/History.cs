using System.Collections.Generic;
using SudokuSolver.Model.Logger;

namespace SudokuSolver.Model.Sudoku
{
    //todo - this is caretaker class, maybe more creative name for it - out of ideas atm
    public class History
    {
        private readonly Stack<Memento> _undoStack = new Stack<Memento>();

        public void AddUndoMemento(Memento memento)
        {
            _undoStack.Push(memento);
            LoggingFacade.Info($"History size: {_undoStack.Count}");
        }
        
        public Memento GetUndoMemento()
        {
            return _undoStack.Pop();
        }
        
        public bool IsUndoPossible()
        {
            return _undoStack.Count > 0;
        }

        public void Clear()
        {
            _undoStack.Clear();
            LoggingFacade.Info("Clearing history");
        }
    }
}