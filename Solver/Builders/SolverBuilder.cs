using SudokuGrabber.Grabber.Digit;
using SudokuGrabber.Grabber.Sudoku;
using SudokuGrabber.Recognizer;

namespace SudokuGrabber.Builders
{
    public class SolverBuilder 
    {
    
        private  ISudokuPositionGrabber _sudokuGrabber;
       
        private  IDigitGrabber _digitGrabber;
       
        private  IDigitRecognizer _digitRecognizer;


       
   

        public SolverBuilder SetDigitGrabber(IDigitGrabber digitGrabber)
        {
            _digitGrabber = digitGrabber;
            return this;
        }

        public SolverBuilder SetSudokuGrabber(ISudokuPositionGrabber sudokuGrabber)
        {
            _sudokuGrabber = sudokuGrabber;
            return this;
        }

        public SolverBuilder SetDigitRecognizer(IDigitRecognizer digitRecognizer)
        {
            _digitRecognizer = digitRecognizer;
            return this;
        }

        

        public ISudokuGrabber GetSolver()
        {
            return  new SudokuGrabber(
                _sudokuGrabber,
                _digitGrabber,
                _digitRecognizer);
        }
    }
}
