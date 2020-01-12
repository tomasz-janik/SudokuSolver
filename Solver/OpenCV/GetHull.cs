using Emgu.CV;
using Emgu.CV.Util;
using Solver.OpenCV.Interfaces;

namespace Solver.OpenCV
{
    public class GetHull: ICalcHull
    {
        public VectorOfPoint Get(VectorOfPoint contour)
        {
            var hull = new VectorOfPoint();
            CvInvoke.ConvexHull(contour, hull);
            return hull;
        }
    }
}
