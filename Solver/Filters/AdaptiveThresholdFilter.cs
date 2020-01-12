using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace Solver.Filters
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

        public AdaptiveThresholdFilter(int maxValue, AdaptiveThresholdType adaptiveThresholdType, ThresholdType thresholdType, int blockSize, int c)
        {
            _maxValue = maxValue;
            _adaptiveThresholdType = adaptiveThresholdType;
            _thresholdType = thresholdType;
            _blockSize = blockSize;
            _c = c;
        }

        public void Apply(Mat image)
        {
            CvInvoke.AdaptiveThreshold(image, image, _maxValue, _adaptiveThresholdType, _thresholdType, _blockSize, _c);
        }
    }
}
