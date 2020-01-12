using System;
using System.Collections.Generic;
using System.Text;
using Solver.Filters;
using Solver.Grabber.Digit;
using Solver.Grabber.Digit.Strategies;
using Solver.Grabber.Sudoku;

namespace Solver.Builders
{
    public class StaticSizeDigitGrabberBuilder
    {
        private  IEnumerable<IFilter> _preDigitGrabFilters;
        private  IDigitGrabStrategy _digitGrabStrategy;
        private  IDigitCleanStrategy _digitCleanStrategy;

        public StaticSizeDigitGrabberBuilder SetPreDigitGrabFilters(IEnumerable<IFilter> preDigitGrabFilters)
        {
            _preDigitGrabFilters = preDigitGrabFilters;
            return this;
        }

        public StaticSizeDigitGrabberBuilder SetDigitCleanStrategy(IDigitCleanStrategy digitCleanStrategy)
        {
            _digitCleanStrategy = digitCleanStrategy;
            return this;
        }

        public StaticSizeDigitGrabberBuilder SetDigitGrabStrategy(IDigitGrabStrategy digitGrabStrategy)
        {
            _digitGrabStrategy = digitGrabStrategy;
            return this;
        }

        public IDigitGrabber GetGrabber()
        {
            return new StaticSizeDigitGrabber(_preDigitGrabFilters, _digitGrabStrategy, _digitCleanStrategy);
        }
    }
}
