using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace SudokuGrabber.Filters
{
    public class DeskewImage : IFilter
    {
        private readonly int _size;

        public DeskewImage(int size)
        {
            _size = size;
        }

        public void Apply(Mat image)
        {
            using var moments = CvInvoke.Moments(image);
            if (moments.Mu02 < 1e-2)
                return;

            var skew = moments.Mu11 / moments.Mu02;

            var mat = new Matrix<double>(2, 3)
            {
                [0, 0] = 1,
                [0, 1] = skew,
                [0, 2] = -0.5 * _size * skew,
                [1, 0] = 0,
                [1, 1] = 1,
                [1, 2] = 0
            };


            CvInvoke.WarpAffine(image, image, mat, new Size(_size, _size), Inter.Linear, Warp.InverseMap);
        }
    }
}
