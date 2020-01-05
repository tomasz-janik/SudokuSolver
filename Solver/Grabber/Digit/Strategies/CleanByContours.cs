﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;

namespace Solver.Grabber.Digit.Strategies
{
    public class CleanByContours : IDigitCleanStrategy
    {
        public Mat Clean(Mat digit)
        {
            var cont = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(digit, cont, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            var points = new List<Point>();
            for (int i = 0; i < cont.Size; i++)
            {
                var rect = CvInvoke.BoundingRectangle(cont[i]);

                double aspect = (double)rect.Height / (double)rect.Width;
                double area = rect.Height * rect.Width;

                if (aspect > 0.3 && aspect < 4 && area > 50)
                {
                    points.AddRange(cont[i].ToArray());
                }
            }

            var rectTest = CvInvoke.BoundingRectangle(new VectorOfPoint(points.ToArray()));
            var result = new Mat(digit, rectTest);

            digit.Dispose();
            return result;
        }
    }
}
