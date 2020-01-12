using Emgu.CV;

namespace Solver.Grabber.Sudoku.PreGrab
{
    public interface IPreSudokuGrab
    {
        void Apply(Mat image);
    }
}
