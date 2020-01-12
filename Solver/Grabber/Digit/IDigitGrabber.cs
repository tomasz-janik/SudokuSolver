using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;
using Solver.Models;

namespace Solver.Grabber.Digit
{
    public interface IDigitGrabber
    {
        Sudoku<Mat> GetDigits(Mat image);

    }
}
