using System.Collections.Generic;
using Emgu.CV;
using Solver.Filters;

namespace Solver.Grabber.Sudoku.PreGrab
{
    public class PreSudokuGrab : IPreSudokuGrab
    {
        private readonly IEnumerable<IFilter> _filters;
        public PreSudokuGrab(IEnumerable<IFilter> filters)
        {
            _filters = filters;
        }
        public void Apply(Mat image)
        {
            foreach (var filter in _filters)
            {
                filter.Apply(image);
            }
        }
    }
}
