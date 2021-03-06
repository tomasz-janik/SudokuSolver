﻿using System.Collections.Generic;
using SudokuGrabber.Filters;
using SudokuGrabber.Grabber.Sudoku;
using SudokuGrabber.OpenCV.Interfaces;

namespace SudokuGrabber.Builders
{
    public class BaseSudokuGrabberBuilder
    {
        private List<IFilter> _preSudokuGrabFilters = new List<IFilter>();
        private ICalcContours _calcContours;
        private ICalcHull _calcHull;
        private ICalcCorners _calcCorners;
        private IPerspectiveWrap _perspectiveWrap;

        public BaseSudokuGrabberBuilder SetPreSudokuGrabFilters(List<IFilter> filters)
        {
            _preSudokuGrabFilters = filters;
            return this;
        }

        public BaseSudokuGrabberBuilder AddPreSudokuGrabFilters(IFilter filter)
        {
            _preSudokuGrabFilters.Add(filter);
            return this;
        }

        public BaseSudokuGrabberBuilder SetCalcCorners(ICalcCorners calcCorners)
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

        public ISudokuPositionGrabber GetGrabber()
        {
            return new BaseSudokuSudokuGrabber(_preSudokuGrabFilters,_calcContours, _calcHull,_calcCorners,_perspectiveWrap);
        }
    }
}
