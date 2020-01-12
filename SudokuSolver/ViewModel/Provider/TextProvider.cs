using System;
using System.Collections.Generic;
using System.Text;
using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.ViewModel.Provider
{
    class TextProvider : ISpecificProvider
    {
        public string GetExtension()
        {
            return ".txt";
        }

        public List<List<Cell>> Provide(string path)
        {
            throw new NotImplementedException();
        }
    }
}
