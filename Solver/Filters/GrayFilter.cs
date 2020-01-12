using Emgu.CV;
using Emgu.CV.CvEnum;

namespace SudokuGrabber.Filters
{
    public  interface IGrayFilter :IFilter { }
    public class GrayFilter : IGrayFilter
    {
        public void Apply(Mat image)
        {
            CvInvoke.CvtColor(image, image, ColorConversion.Bgr2Gray);
        }
    }
}
