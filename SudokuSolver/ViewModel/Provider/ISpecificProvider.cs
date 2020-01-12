using System;
using System.Collections.Generic;
using System.Text;
using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.ViewModel.Provider
{
    public interface ISpecificProvider
    {
        string GetExtension();
        List<List<Cell>> Provide(string path);
    }
}
