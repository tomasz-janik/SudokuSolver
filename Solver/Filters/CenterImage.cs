using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace SudokuGrabber.Filters
{
    public  interface  ICenterImage : IFilter { }
    public class CenterImage : ICenterImage
    {
        private readonly int _size;

        public CenterImage(int size)
        {
            _size = size;
        }

        public void Apply(Mat image)
        {
            var s = (float)(1.5 * image.Height / _size);

            using var moments = CvInvoke.Moments(image);

            var c10 = (float)(moments.M10 / moments.M00);
            var c11 = (float)(moments.M01 / moments.M00);

            var c00 = _size / 2;
            var c01 = _size / 2;

            var t0 = c10 - s * c00;
            var t1 = c11 - s * c01;

            var mat = new Matrix<double>(2, 3)
            {
                [0, 0] = s,
                [0, 1] = 0,
                [0, 2] = t0,
                [1, 0] = 0,
                [1, 1] = s,
                [1, 2] = t1
            };

            CvInvoke.WarpAffine(image, image, mat, new Size(_size, _size), Inter.Linear, Warp.InverseMap);
        }
    }
}
