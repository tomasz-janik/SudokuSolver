using Emgu.CV;

namespace SudokuGrabber.Recognizer.Strategies
{
    public  interface IRecognizer
    {
        int Recognize(Mat image);
    }
}
