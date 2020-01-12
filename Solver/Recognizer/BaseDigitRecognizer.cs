using System.Collections.Generic;
using Emgu.CV;
using SudokuGrabber.Filters;
using SudokuGrabber.Recognizer.Strategies;

namespace SudokuGrabber.Recognizer
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
