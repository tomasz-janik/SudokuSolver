using Emgu.CV;
using Emgu.CV.Util;
using Solver.OpenCV.Interfaces;

namespace Solver.OpenCV
{
    public class GetCorners : ICalcCorners
    {
        private readonly int _maxIterations;

        public GetCorners()
        {
            _maxIterations = 4000;
        }
        public GetCorners(int maxIterations)
        {
            _maxIterations = maxIterations;
        }

        public VectorOfPointF Get(VectorOfPoint hull)
        {
            double left = 0.0;
            double right = 1.0;
            
            VectorOfPointF dst = new VectorOfPointF();

            for (int i = 0; i < _maxIterations; i++)
            {
                var arcLength = CvInvoke.ArcLength(hull, true);
                double k = (right + left) / 2.0; 
                double eps = k * arcLength;

               
                CvInvoke.ApproxPolyDP(hull, dst, eps * arcLength, true);

                if (dst.Size == 4)
                {
                    return dst;
                }

                if (dst.Size > 4) 
                {
                    left = k;
                }
                else
                {
                    right = k;
                }

            }

            return null;
        }
    }
}
