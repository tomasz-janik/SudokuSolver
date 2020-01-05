using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;
using Emgu.CV.Util;

namespace Solver.Modifiers.Interfaces
{
    public interface IPerspectiveWrap
    {
        void Apply(Mat image, VectorOfPointF corners);
    }
}
