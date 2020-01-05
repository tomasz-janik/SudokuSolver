using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;

namespace Solver.Recognizer
{
    public interface IDigitRecognizer
    {
        int Recognize(Mat digit);
    }
}
