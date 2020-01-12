using Emgu.CV.Util;

namespace SudokuGrabber.OpenCV.Interfaces
{
    public interface ICalcCorners
    {
        VectorOfPointF Get(VectorOfPoint hull);
    }
}
