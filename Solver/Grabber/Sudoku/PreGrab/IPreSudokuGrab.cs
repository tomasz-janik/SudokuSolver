using Emgu.CV;

namespace SudokuGrabber.Grabber.Sudoku.PreGrab
{
    public interface IPreSudokuGrab
    {
        void Apply(Mat image);
    }
}
