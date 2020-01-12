using System;
using System.Collections.Generic;
using System.Text;
using Solver.Filters;
using Solver.Recognizer;
using Solver.Recognizer.Strategies;

namespace Solver.Builders
{
    public  class BaseDigitRecognizerBuilder
    {
        private  IEnumerable<IFilter> _preDigitRecognizeFilters;
        private  IRecognizer _recognizer;

        public BaseDigitRecognizerBuilder SetPreDigitRecognizeFilters(IEnumerable<IFilter> filters)
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
