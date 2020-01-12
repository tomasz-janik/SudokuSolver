using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;
using Solver.Models;

namespace Solver.Grabber.Digit.Strategies
{
    public interface IDigitGrabStrategy
    {
        Sudoku<Mat> Grab(Mat image);

    }
}
