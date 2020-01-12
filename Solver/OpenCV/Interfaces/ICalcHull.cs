using Emgu.CV.Util;

namespace Solver.OpenCV.Interfaces
{
    public  interface ICalcHull
    {
        VectorOfPoint Get(VectorOfPoint contour);
    }
}
