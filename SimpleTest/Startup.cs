using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Emgu.CV.CvEnum;
using Microsoft.Extensions.DependencyInjection;
using Solver;
using Solver.Builders;
using Solver.Filters;
using Solver.Grabber.Digit;
using Solver.Grabber.Digit.Strategies;
using Solver.Grabber.Sudoku;
using Solver.Grabber.Sudoku.PreGrab;
using Solver.OpenCV;
using Solver.OpenCV.Interfaces;
using Solver.Recognizer;
using Solver.Recognizer.Strategies;

namespace SimpleTest
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICalcContours, GetContours>();
            services.AddSingleton<ICalcHull,GetHull>();
            services.AddSingleton<ICalcCorners, GetCorners>();
            services.AddSingleton<IDigitCleanStrategy, CleanByContours>();
            SetSudokuGrabber(services);
        }

        private void SetSudokuGrabber(IServiceCollection services)
        {
           
            services.AddSingleton<ISudokuGrabber>(serv => 
                Builders.NewBaseSudokuGrabberBuilder()
                    .SetCalcContours(serv.GetService<ICalcContours>())
                    .SetCalcHull(serv.GetService<ICalcHull>())
                    .SetCalcCorners(serv.GetService<ICalcCorners>())
                    .SetPerspectiveWrap(new StaticPerspectiveWrap(900))
                    .SetPreSudokuGrabFilters(new List<IFilter>
                    {
                        new GrayFilter(),
                        new AdaptiveThresholdFilter(255, AdaptiveThresholdType.GaussianC, ThresholdType.BinaryInv, 21,
                            2),
                        new FastDeNoisingFilter(100, 5, 5)
                    })
                    .GetGrabber()
            );


            services.AddSingleton<IDigitRecognizer>(serv =>
                Builders.NewBaseDigitRecognizerBuilder().SetPreDigitRecognizeFilters(
                        new List<IFilter>()
                        {
                            new CenterImage(28),
                            new DeskewImage(28)
                        })
                    .SetRecognizer(new SVMRecognizer())
                    .GetDigitRecognizer()
            );

            services.AddSingleton<IDigitGrabber>(serv =>
                Builders.NewStaticSizeDigitGrabber()
                    .SetDigitCleanStrategy(serv.GetService<IDigitCleanStrategy>())
                    .SetDigitGrabStrategy(new GrabBySize())
                    .SetPreDigitGrabFilters(new List<IFilter>()
                    {
                        new CLeanLineImage(new GrayFilter() ,new MedianBlurFilter(3))
                    })
                    .GetGrabber()
            );

            services.AddSingleton<ISudokuSolver,SudokuSolver>();
        }
    }
}
