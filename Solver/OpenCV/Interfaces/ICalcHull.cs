using Emgu.CV.Util;

namespace SudokuGrabber.OpenCV.Interfaces
{
    public  interface ICalcHull
    {
        VectorOfPoint Get(VectorOfPoint contour);
    }
}
