using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;
using Solver.Filters;
using Solver.Recognizer.Strategies;

namespace Solver.Recognizer
{
    public class BaseDigitRecognizer : IDigitRecognizer
    {
        private readonly IEnumerable<IFilter> _preDigitRecognizeFilters;
        private readonly IRecognizer _recognizer;

        public BaseDigitRecognizer(IEnumerable<IFilter> preDigitRecognizeFilters, IRecognizer recognizer)
        {
            _preDigitRecognizeFilters = preDigitRecognizeFilters;
            _recognizer = recognizer;
        }

        public int Recognize(Mat digit)
        {
            foreach (var preDigitRecognizeFilter in _preDigitRecognizeFilters)
            {
                preDigitRecognizeFilter.Apply(digit);
            }

            return _recognizer.Recognize(digit);
        }
    }
}
