using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace Solver.Filters
{
    public  interface IGrayFilter :IFilter { }
    public class GrayFilter : IGrayFilter
    {
        public void Apply(Mat image)
        {
            CvInvoke.CvtColor(image, image, ColorConversion.Bgr2Gray);
        }
    }
}
