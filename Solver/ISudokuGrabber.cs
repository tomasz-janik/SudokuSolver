using SudokuGrabber.Models;

namespace SudokuGrabber
{
    public interface ISudokuGrabber
    {
        Sudoku<int> Grab(string pathImage);
    
    }
}
