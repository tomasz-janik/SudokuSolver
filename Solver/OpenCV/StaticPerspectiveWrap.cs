using System.Drawing;
using System.Linq;
using Emgu.CV;
using Emgu.CV.Util;
using SudokuGrabber.OpenCV.Interfaces;

namespace SudokuGrabber.OpenCV
{
   public class StaticPerspectiveWrap : IPerspectiveWrap
   {
       private readonly int _size;

       public StaticPerspectiveWrap(int size)
       {
           _size = size;
       }

       public StaticPerspectiveWrap()
       {
           _size = 900;
       }
       public void Apply(Mat image, VectorOfPointF corners)
        {
            var sortedCorners = corners.ToArray().OrderBy(x => x.X).ToArray();
            SwapCorners(sortedCorners);

            var points = new PointF[]
            { 
                new PointF(0, 0),
                new PointF(0, _size),
                new PointF(_size, _size),
                new PointF(_size, 0),
            };

            var newImage = new VectorOfPointF(points);

            Mat mask = null;
            mask = CvInvoke.GetPerspectiveTransform(sortedCorners, points);

            CvInvoke.WarpPerspective(image, image, mask, new Size(_size, _size));
        }

        private void SwapCorners(PointF[] corners)
        {
            PointF tempPoint = corners[0];
            if (corners[1].Y < tempPoint.Y)
            {
                corners[0] = corners[1];
                corners[1] = tempPoint;
            }

            tempPoint = corners[2];
            if (corners[3].Y > tempPoint.Y )
            {
                corners[2] = corners[3];
                corners[3] = tempPoint;
            }
        }
    }
}
