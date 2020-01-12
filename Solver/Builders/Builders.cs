﻿using System;
using System.Collections.Generic;
using System.Text;
using Solver.Grabber.Digit;

namespace Solver.Builders
{
    public static class  Builders
    {
       public static SolverBuilder NewSolverBuilder()
        {
            return new SolverBuilder();
        }

       public static BaseSudokuGrabberBuilder NewBaseSudokuGrabberBuilder()
       {
           return new BaseSudokuGrabberBuilder();
       }

       public static StaticSizeDigitGrabberBuilder NewStaticSizeDigitGrabber()
       {
           return new StaticSizeDigitGrabberBuilder();
       }

        public static BaseDigitRecognizerBuilder NewBaseDigitRecognizerBuilder()
        {
            return new BaseDigitRecognizerBuilder();
        }
    }
}
