using System.Collections.Generic;
using Emgu.CV;
using SudokuGrabber.Extensions;
using SudokuGrabber.Filters;
using SudokuGrabber.Grabber.Digit.Strategies;
using SudokuGrabber.Models;

namespace SudokuGrabber.Grabber.Digit
{
   public  class StaticSizeDigitGrabber : IDigitGrabber
   {
       private readonly IEnumerable<IFilter> _preDigitGrabFilters;
       private readonly IDigitGrabStrategy _digitGrabStrategy;
       private readonly IDigitCleanStrategy _digitCleanStrategy;
       public StaticSizeDigitGrabber(IEnumerable<IFilter> preDigitGrabFilters, IDigitGrabStrategy digitGrabStrategy, IDigitCleanStrategy digitCleanStrategy)
       {
           _preDigitGrabFilters = preDigitGrabFilters;
           _digitGrabStrategy = digitGrabStrategy;
           _digitCleanStrategy = digitCleanStrategy;
       }

       public Sudoku<Mat> GetDigits(Mat image)
       {
           foreach (var preDigitGrabFilter in _preDigitGrabFilters)
           {
               preDigitGrabFilter.Apply(image);
           }

           image.ShowImage();

            var sudoku = _digitGrabStrategy.Grab(image);
           
           for (var i = 0; i < 9; i++)
           {
               for (var j = 0; j < 9; j++)
               {
                   sudoku.Digits[i, j] = _digitCleanStrategy.Clean(sudoku.Digits[i, j]);
               }
           }

           return sudoku;
       }
   }
}
