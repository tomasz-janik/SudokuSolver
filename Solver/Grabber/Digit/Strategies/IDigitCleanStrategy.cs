using Emgu.CV;

namespace SudokuGrabber.Grabber.Digit.Strategies
{
    public interface IDigitCleanStrategy
    {
        Mat Clean(Mat digit);
    }
}
