using System.Collections.Generic;
using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.ViewModel.Provider
{
    public interface IFileProvider
    {
        List<List<Cell>> Provide(string path);
    }
}