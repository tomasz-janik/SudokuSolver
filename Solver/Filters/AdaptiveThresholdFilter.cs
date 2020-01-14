using Emgu.CV;
using Emgu.CV.CvEnum;

namespace SudokuGrabber.Filters
{
    public class AdaptiveThresholdFilter : IFilter
    {
        private readonly int _maxValue;
        private readonly AdaptiveThresholdType _adaptiveThresholdType;
        private readonly ThresholdType _thresholdType;
        private readonly int _blockSize;
        private readonly int _c;

        public AdaptiveThresholdFilter()
        {
            _maxValue = 255;
            _adaptiveThresholdType = AdaptiveThresholdType.GaussianC;
            _thresholdType = ThresholdType.BinaryInv;
            _blockSize = 21;
            _c = 2;
        }

        public void Apply(Mat image)
        {
            CvInvoke.AdaptiveThreshold(image, image, _maxValue, _adaptiveThresholdType, _thresholdType, _blockSize, _c);
        }
    }
}
