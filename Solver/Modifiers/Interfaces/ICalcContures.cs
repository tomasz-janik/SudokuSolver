using Emgu.CV;
using Solver.Models;

namespace Solver.Modifiers.Interfaces
{
    public interface ICalcContours
    {
        Contour Get(Mat image);
    }
}
