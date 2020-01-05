using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Util;
using Solver.Modifiers.Interfaces;

namespace Solver.Modifiers
{
   public class StaticPerspectiveWrap : IPerspectiveWrap
    {
        public void Apply(Mat image, VectorOfPointF corners)
        {
            var sortedCorners = corners.ToArray().OrderBy(x => x.X).ToArray();
            SwapCorners(sortedCorners);

            var points = new PointF[]
            { 
                new PointF(0, 0),
                new PointF(0, 900),
                new PointF(900, 900),
                new PointF(900, 0),
            };

            var newImage = new VectorOfPointF(points);

            Mat mask = null;
            mask = CvInvoke.GetPerspectiveTransform(sortedCorners, points);

            CvInvoke.WarpPerspective(image, image, mask, new Size(900, 900));
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
