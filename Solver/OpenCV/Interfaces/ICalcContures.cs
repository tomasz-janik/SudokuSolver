using Emgu.CV;
using SudokuGrabber.Models;

namespace SudokuGrabber.OpenCV.Interfaces
{
    public interface ICalcContours
    {
        Contour Get(Mat image);
    }
}
