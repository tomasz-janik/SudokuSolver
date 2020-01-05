using System;
using System.Buffers;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.ML;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Microsoft.VisualBasic.CompilerServices;
using Solver.Extensions;
using Solver.Filters;
using Solver.Grabber;
using Solver.Grabber.Digit;
using Solver.Grabber.Sudoku;
using Solver.Models;
using Solver.Recognizer;

namespace Solver
{
    public class SudokuSolver : ISudokuSolver
    {
     
        private readonly ISudokuGrabber _sudokuGrabber;
        private readonly IDigitGrabber _digitGrabber; 
        private readonly IDigitRecognizer _digitRecognizer;

        public SudokuSolver( 
            ISudokuGrabber sudokuGrabber,
            IDigitGrabber digitGrabber,
            IDigitRecognizer digitRecognizer)
        {
            _sudokuGrabber = sudokuGrabber;
            _digitGrabber = digitGrabber;
            _digitRecognizer = digitRecognizer;

        }

        public Sudoku<int> Solve(Mat image)
        {
            using var imageCopy = image.Clone();

            var result = new Sudoku<int>();
            var grid = _sudokuGrabber.Grab(image);
            var sudoku = _digitGrabber.GetDigits(grid);

            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    var digit = sudoku.Digits[i, j];
                    if (!digit.IsEmpty)
                    {
                        result.Digits[i, j] = _digitRecognizer.Recognize(digit);
                    }
                    else
                    {
                        result.Digits[i, j] = 0;;
                    }
                 
                }
            }

            Console.WriteLine( result.ToString());
            return result;
        }

     
    }
}
