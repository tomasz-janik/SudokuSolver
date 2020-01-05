using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Emgu.CV;
using Emgu.CV.Util;
using Solver.Models;

namespace Solver.Grabber.Digit.Strategies
{
   public  class GrabBySize : IDigitGrabStrategy
    {
        public Sudoku<Mat> Grab(Mat image)
        {
            var result = new Sudoku<Mat>();
            int height = image.Size.Height / 9;
            int width = image.Size.Width / 9;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var points = new Point[]
                    {

                        new Point(j * width, i * height),
                        new Point((j + 1) * width-1, i * height),
                        new Point((j + 1) * width-1, (i + 1) * height-1),
                        new Point(j * width, (i + 1) * height-1),
                    };
                    var rect = CvInvoke.BoundingRectangle(new VectorOfPoint(points));
                    result.Digits[i,j] = new Mat(image, rect);
                }
            }

            return result;
        }
    }
}
