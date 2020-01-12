using Emgu.CV;
using Emgu.CV.Util;

namespace SudokuGrabber.Models
{
    public class Contour
    {
        public VectorOfVectorOfPoint Data => _contours;
        private readonly VectorOfVectorOfPoint _contours;

        public Contour(VectorOfVectorOfPoint contours)
        {
            _contours = contours;
        }

        public VectorOfPoint GetBiggest()
        {
            return _contours[BiggestIndex()];
        }

        private int BiggestIndex()
        {
            double maxArea = 0;
            var p = -1;

            for (var i = 0; i < _contours.Size; i++)
            {
                var area = CvInvoke.ContourArea(_contours[i], false);
                if (area > maxArea)
                {
                    maxArea = area;
                    p = i;
                }
            }

            return p;
        }
    }
}
