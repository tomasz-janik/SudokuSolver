using Emgu.CV;

namespace SudokuGrabber.Grabber.Sudoku
{
    public interface ISudokuPositionGrabber
    {
        Mat Grab(Mat image);
    }
}
