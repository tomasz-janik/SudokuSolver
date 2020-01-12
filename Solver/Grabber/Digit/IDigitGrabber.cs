using Emgu.CV;
using SudokuGrabber.Models;

namespace SudokuGrabber.Grabber.Digit
{
    public interface IDigitGrabber
    {
        Sudoku<Mat> GetDigits(Mat image);

    }
}
