using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Solver.Models;
using Solver.OpenCV.Interfaces;

namespace Solver.OpenCV
{ 
    public class GetContours : ICalcContours
    {
        private readonly RetrType _retrType;
        private readonly ChainApproxMethod _approxMethod;

        public GetContours()
        {
            _retrType = RetrType.External;
            _approxMethod = ChainApproxMethod.ChainApproxNone;
        }
        public GetContours(RetrType retrType, ChainApproxMethod approxMethod)
        {
            _retrType = retrType;
            _approxMethod = approxMethod;
        }

        public Contour Get(Mat image)
        {
            var contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(image, contours, null, _retrType, _approxMethod);
            return new Contour(contours);
        }
    }
}
