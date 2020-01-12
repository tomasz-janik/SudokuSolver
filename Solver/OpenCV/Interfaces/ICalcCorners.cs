using Emgu.CV.Util;

namespace Solver.OpenCV.Interfaces
{
    public interface ICalcCorners
    {
        VectorOfPointF Get(VectorOfPoint hull);
    }
}
