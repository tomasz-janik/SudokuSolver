using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.Utils;

namespace SudokuSolver.ViewModel.Provider
{
    class FileProvider : IFileProvider
    {
        private readonly IEnumerable<ISpecificProvider> _providers;

        public FileProvider(IEnumerable<ISpecificProvider> providers)
        {
            _providers = providers;
        }

        public List<List<Cell>> Provide(string path)
        {
            var dotIndex = path.IndexOf('.');
            var pathExt = path.Substring(dotIndex);

            foreach (var specificProvider in _providers)
            {
                if (specificProvider.GetExtension().Contains(pathExt))
                {
                    return specificProvider.Provide(path);
                }
            }

            return null;
        }
    }
}
