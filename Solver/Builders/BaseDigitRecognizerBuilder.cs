using System.Collections.Generic;
using SudokuGrabber.Filters;
using SudokuGrabber.Recognizer;
using SudokuGrabber.Recognizer.Strategies;

namespace SudokuGrabber.Builders
{
    public  class BaseDigitRecognizerBuilder
    {
        private List<IFilter> _preDigitRecognizeFilters = new List<IFilter>();
        private  IRecognizer _recognizer;

        public BaseDigitRecognizerBuilder SetPreDigitRecognizeFilters(List<IFilter> filters)
        {
            _preDigitRecognizeFilters = filters;
            return this;
        }

        public BaseDigitRecognizerBuilder SetRecognizer(IRecognizer recognizer)
        {
            _recognizer = recognizer;
            return this;
        }

        public IDigitRecognizer GetDigitRecognizer()
        {
            return new BaseDigitRecognizer(_preDigitRecognizeFilters,_recognizer);
        }
    }
}
