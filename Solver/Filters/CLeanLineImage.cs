using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace SudokuGrabber.Filters
{
    public class CLeanLineImage : IFilter
    {
        private readonly IGrayFilter _grayFilter;
        private readonly IMedianBlurFilter _medianBlurFilter;

        public CLeanLineImage(IGrayFilter grayFilter, IMedianBlurFilter medianBlurFilter) //TODO
        {
            _grayFilter = grayFilter;
            _medianBlurFilter = medianBlurFilter;
        }

        public void Apply(Mat image)
        {

            _grayFilter.Apply(image);
            _medianBlurFilter.Apply(image);

            LineSegment2D[] lines;
            using (var lineFinder = image.Clone())
            {
                CvInvoke.AdaptiveThreshold(lineFinder, lineFinder, 255, AdaptiveThresholdType.GaussianC, ThresholdType.BinaryInv, 31, 15);
                lines = CvInvoke.HoughLinesP(lineFinder, 1, Math.PI / 180, 50, 65, 5);
            }
            
            CvInvoke.AdaptiveThreshold(image, image, 255, AdaptiveThresholdType.GaussianC, ThresholdType.BinaryInv, 7, 2);

            foreach (var line in lines)
            {
                CvInvoke.Line(image, line.P1, line.P2, new MCvScalar(0.0, 0, 0.0), 3);
            }
        }
    }
}
