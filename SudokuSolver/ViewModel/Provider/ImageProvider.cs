using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SudokuGrabber;
using SudokuSolver.Extensions;
using SudokuSolver.Model.Sudoku;

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
