using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV.Util;
using Solver.Models;

namespace Solver.Modifiers.Interfaces
{
    public interface ICalcCorners
    {
        VectorOfPointF Get(VectorOfPoint hull);
    }
}
