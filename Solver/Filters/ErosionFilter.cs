using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace SudokuGrabber.Filters
{
    public class ErosionFilter : IFilter
    {
        private readonly int _erosionSize;
        private readonly ElementShape _elementShape;

        public ErosionFilter()
        {
            _erosionSize = 2;
            _elementShape = ElementShape.Rectangle;
        }
        public ErosionFilter(int erosionSize, ElementShape elementShape)
        {
            _erosionSize = erosionSize;
            _elementShape = elementShape;
        }

        public void Apply(Mat image)
        {
            Mat element = CvInvoke.GetStructuringElement(_elementShape,
                new Size(2 * _erosionSize + 1, 2 * _erosionSize + 1),
                new Point(_erosionSize, _erosionSize));
        }
    }
}
