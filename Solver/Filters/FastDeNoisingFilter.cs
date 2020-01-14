using Emgu.CV;

namespace SudokuGrabber.Filters
{
    public class FastDeNoisingFilter:IFilter
    {
        private readonly int _h;
        private readonly int _templateWindowSize;
        private readonly int _searchWindowSize;

        public FastDeNoisingFilter(int h, int templateWindowSize, int searchWindowSize)
        {
            _h = h;
            _templateWindowSize = templateWindowSize;
            _searchWindowSize = searchWindowSize;
        }

        public void Apply(Mat image)
        {
            CvInvoke.FastNlMeansDenoising(image, image, _h, _templateWindowSize, _searchWindowSize);
        }
    }
}
