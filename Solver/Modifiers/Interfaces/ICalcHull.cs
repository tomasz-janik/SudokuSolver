using Emgu.CV;
using Emgu.CV.Util;
using Solver.Models;

namespace Solver.Modifiers.Interfaces
{
    public  interface ICalcHull
    {
        VectorOfPoint Get(VectorOfPoint contour);
    }
}
