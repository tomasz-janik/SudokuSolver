using System.Collections.Generic;
using System.Linq;
using SudokuGrabber;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.Utils;

namespace SudokuSolver.ViewModel.Provider
{
    class ImageProvider : ISpecificProvider
    {
        private readonly ISudokuGrabber _sudokuGrabber;

        public ImageProvider(ISudokuGrabber sudokuGrabber)
        {
            _sudokuGrabber = sudokuGrabber;
        }

        public string GetExtension()
        {
            return ".jpg|.png";
        }

        public List<List<Cell>> Provide(string path)
        {
            return _sudokuGrabber.Grab(path)
                .ToListOfList()
                .Select(x =>
                    x.Select(y => y.ToCell())
                        .ToList()
                ).ToList();
        }
    }
}