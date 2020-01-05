using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;

namespace Solver.Filters
{
    public  interface  IMedianBlurFilter : IFilter { }
    public class MedianBlurFilter  : IMedianBlurFilter
    {
        private readonly int _size;

        public MedianBlurFilter()
        {
            _size = 3;
        }
        public MedianBlurFilter(int size)
        {
            _size = size;
        }

        public void Apply(Mat image)
        {
            CvInvoke.MedianBlur(image, image, _size);
        }
    }
}
