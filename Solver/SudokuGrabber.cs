using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using SudokuGrabber.Extensions;
using SudokuGrabber.Grabber.Digit;
using SudokuGrabber.Grabber.Sudoku;
using SudokuGrabber.Models;
using SudokuGrabber.Recognizer;

namespace SudokuGrabber
{
    public class SudokuGrabber : ISudokuGrabber
    {
        private readonly ISudokuPositionGrabber _sudokuGrabber;
        private readonly IDigitGrabber _digitGrabber; 
        private readonly IDigitRecognizer _digitRecognizer;

        public SudokuGrabber( 
            ISudokuPositionGrabber sudokuGrabber,
            IDigitGrabber digitGrabber,
            IDigitRecognizer digitRecognizer)
        {
            _sudokuGrabber = sudokuGrabber;
            _digitGrabber = digitGrabber;
            _digitRecognizer = digitRecognizer;

        }

        public Sudoku<int> Grab(string pathImage)
        {
            using var image = CvInvoke.Imread(pathImage, ImreadModes.AnyColor);

            var result = new Sudoku<int>();
            var grid = _sudokuGrabber.Grab(image);
            grid.ShowImage();
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

          
            return result;
        }
    }
}

