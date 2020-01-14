using System.Collections.Generic;
using SudokuGrabber.Filters;
using SudokuGrabber.Grabber.Digit;
using SudokuGrabber.Grabber.Digit.Strategies;

namespace SudokuGrabber.Builders
{
    public class StaticSizeDigitGrabberBuilder
    {
        private List<IFilter> _preDigitGrabFilters = new List<IFilter>();
        private  IDigitGrabStrategy _digitGrabStrategy;
        private  IDigitCleanStrategy _digitCleanStrategy;

        public StaticSizeDigitGrabberBuilder SetPreDigitGrabFilters(List<IFilter> preDigitGrabFilters)
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
