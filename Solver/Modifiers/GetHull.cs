using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;
using Emgu.CV.Util;
using Solver.Models;
using Solver.Modifiers.Interfaces;

namespace Solver.Modifiers
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
