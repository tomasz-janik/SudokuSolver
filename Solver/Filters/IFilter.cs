using Emgu.CV;

namespace SudokuGrabber.Filters
{
   public interface  IFilter
   {
       void Apply(Mat image);
   }
}
