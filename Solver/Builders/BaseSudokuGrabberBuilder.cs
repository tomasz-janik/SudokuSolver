using System;
using System.Collections.Generic;
using System.Text;
using Solver.Filters;
using Solver.Grabber;
using Solver.Grabber.Sudoku;
using Solver.Grabber.Sudoku.PreGrab;
using Solver.Modifiers.Interfaces;

namespace Solver.Builders
{
    public class BaseSudokuGrabberBuilder
    {
        private IEnumerable<IFilter> _preSudokuGrabFilters;
        private  ICalcContours _calcContours;
        private  ICalcHull _calcHull;
        private  ICalcCorners _calcCorners;
        private  IPerspectiveWrap _perspectiveWrap;

        public BaseSudokuGrabberBuilder SetPreSudokuGrabFilters(IEnumerable<IFilter> filters)
        {
            _preSudokuGrabFilters = filters;
            return this;
        }
        public BaseSudokuGrabberBuilder SetCalcContours(ICalcCorners calcCorners)
        {
            _calcCorners = calcCorners;
            return this;
        }

        public BaseSudokuGrabberBuilder SetCalcHull(ICalcHull calcHull)
        {
            _calcHull = calcHull;
            return this;

        }

        public BaseSudokuGrabberBuilder SetPerspectiveWrap(IPerspectiveWrap perspectiveWrap)
        {
            _perspectiveWrap = perspectiveWrap;
            return this;

        }

        public BaseSudokuGrabberBuilder SetCalcContours(ICalcContours calcContours)
        {
            _calcContours = calcContours;
            return this;

        }

        public ISudokuGrabber GetGrabber()
        {
            return new BaseSudokuSudokuGrabber(_preSudokuGrabFilters,_calcContours, _calcHull,_calcCorners,_perspectiveWrap);
        }
    }
}
