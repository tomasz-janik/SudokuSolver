using Emgu.CV;
using Solver.Models;

namespace Solver.OpenCV.Interfaces
{
    public interface ICalcContours
    {
        Contour Get(Mat image);
    }
}
