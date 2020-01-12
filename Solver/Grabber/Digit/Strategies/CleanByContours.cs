using System.Collections.Generic;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Util;
using SudokuGrabber.OpenCV.Interfaces;

namespace SudokuGrabber.Grabber.Digit.Strategies
{
    public class CleanByContours : IDigitCleanStrategy
    {
        private readonly ICalcContours _calcContours;
        
        public CleanByContours(ICalcContours calcContours)
        {
            _calcContours = calcContours;
      
        }

        public Mat Clean(Mat digit)
        {
            var cont = _calcContours.Get(digit).Data;
           
            var points = new List<Point>();
            for (int i = 0; i < cont.Size; i++)
            {
                var rect = CvInvoke.BoundingRectangle(cont[i]);

                double aspect = (double)rect.Height / (double)rect.Width;
                double area = rect.Height * rect.Width;

                if (aspect > 0.3 && aspect < 4 && area > 100)
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
