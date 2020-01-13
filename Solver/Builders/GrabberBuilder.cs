using SudokuGrabber.Grabber.Digit;
using SudokuGrabber.Grabber.Sudoku;
using SudokuGrabber.Recognizer;

namespace SudokuGrabber.Builders
{
    public class GrabberBuilder 
    {
    
        private  ISudokuPositionGrabber _sudokuGrabber;
       
        private  IDigitGrabber _digitGrabber;
       
        private  IDigitRecognizer _digitRecognizer;


        public GrabberBuilder SetDigitGrabber(IDigitGrabber digitGrabber)
        {
            _digitGrabber = digitGrabber;
            return this;
        }

        public GrabberBuilder SetSudokuGrabber(ISudokuPositionGrabber sudokuGrabber)
        {
            _sudokuGrabber = sudokuGrabber;
            return this;
        }

        public GrabberBuilder SetDigitRecognizer(IDigitRecognizer digitRecognizer)
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
