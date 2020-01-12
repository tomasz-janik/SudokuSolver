using Emgu.CV;
using Emgu.CV.Util;

namespace SudokuGrabber.OpenCV.Interfaces
{
    public interface IPerspectiveWrap
    {
        void Apply(Mat image, VectorOfPointF corners);
    }
}
