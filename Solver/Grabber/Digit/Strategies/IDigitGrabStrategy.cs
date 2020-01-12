using Emgu.CV;
using SudokuGrabber.Models;

namespace SudokuGrabber.Grabber.Digit.Strategies
{
    public interface IDigitGrabStrategy
    {
        Sudoku<Mat> Grab(Mat image);

    }
}
