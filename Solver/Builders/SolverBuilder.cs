using System;
using System.Collections.Generic;
using Solver.Filters;
using Solver.Grabber;
using Solver.Grabber.Digit;
using Solver.Grabber.Sudoku;
using Solver.Recognizer;

namespace Solver.Builders
{
    public class SolverBuilder 
    {
    
        private  ISudokuGrabber _sudokuGrabber;
       
        private  IDigitGrabber _digitGrabber;
       
        private  IDigitRecognizer _digitRecognizer;


       
   

        public SolverBuilder SetDigitGrabber(IDigitGrabber digitGrabber)
        {
            _digitGrabber = digitGrabber;
            return this;
        }

        public SolverBuilder SetSudokuGrabber(ISudokuGrabber sudokuGrabber)
        {
            _sudokuGrabber = sudokuGrabber;
            return this;
        }

        public SolverBuilder SetDigitRecognizer(IDigitRecognizer digitRecognizer)
        {
            _digitRecognizer = digitRecognizer;
            return this;
        }

        

        public ISudokuSolver GetSolver()
        {
            return  new SudokuSolver(
                _sudokuGrabber,
                _digitGrabber,
                _digitRecognizer);
        }
    }
}
