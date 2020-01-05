using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;

namespace Solver.Grabber.Digit.Strategies
{
    public interface IDigitCleanStrategy
    {
        Mat Clean(Mat digit);
    }
}
