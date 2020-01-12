using Emgu.CV;

namespace SudokuGrabber.Recognizer
{
    public interface IDigitRecognizer
    {
        int Recognize(Mat digit);
    }
}
