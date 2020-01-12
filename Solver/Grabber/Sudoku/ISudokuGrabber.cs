using Emgu.CV;

namespace Solver.Grabber.Sudoku
{
    public interface ISudokuGrabber
    {
        Mat Grab(Mat image);
    }
}
