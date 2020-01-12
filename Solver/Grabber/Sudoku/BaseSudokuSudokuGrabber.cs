using System.Collections.Generic;
using Emgu.CV;
using Solver.Filters;
using Solver.Grabber.Sudoku.PreGrab;
using Solver.OpenCV.Interfaces;

namespace Solver.Grabber.Sudoku
{
    public  class  BaseSudokuSudokuGrabber : ISudokuGrabber
    {
        private readonly IEnumerable<IFilter> _preSudokuGrabFilters;
        private readonly ICalcContours _calcContours;
        private readonly ICalcHull _calcHull;
        private readonly ICalcCorners _calcCorners;
        private readonly IPerspectiveWrap _perspectiveWrap;

        public BaseSudokuSudokuGrabber(
            IEnumerable<IFilter>  predPreSudokuGrabFilters,
                                ICalcContours calcContours, 
                                ICalcHull calcHull, 
                                ICalcCorners calcCorners, IPerspectiveWrap perspectiveWrap)
        {
            _preSudokuGrabFilters = predPreSudokuGrabFilters; 
            _calcContours = calcContours;
            _calcHull = calcHull;
            _calcCorners = calcCorners;
            _perspectiveWrap = perspectiveWrap;
        }
        public Mat Grab(Mat image)
        {
            using var cutted = image.Clone();

            foreach (var preSudokuGrabFilter in _preSudokuGrabFilters)
            {
                preSudokuGrabFilter.Apply(cutted);
            }

            var contours = _calcContours.Get(cutted);
            var maxContour = contours.GetBiggest();

            var hull = _calcHull.Get(maxContour);
            var corners = _calcCorners.Get(hull);

            var result = image.Clone();
            _perspectiveWrap.Apply(result, corners);

            return result;
        }

        
    }
}
