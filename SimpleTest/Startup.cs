using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Solver;
using Solver.Builders;
using Solver.Filters;
using Solver.Grabber.Digit;
using Solver.Grabber.Digit.Strategies;
using Solver.Grabber.Sudoku.PreGrab;
using Solver.Modifiers;
using Solver.Recognizer;
using Solver.Recognizer.Strategies;

namespace SimpleTest
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ISudokuSolver>(
                Builders.NewSolverBuilder()
                    .SetDigitRecognizer(new BaseDigitRecognizer(
                        new List<IFilter>()
                        {
                            new CenterImage(),
                            new DeskewImage()
                        }, new SVMRecognizer() ))
                    .SetDigitGrabber(new StaticSizeDigitGrabber(
                        new List<IFilter>()
                        {
                            new CLeanLineImage(new GrayFilter() ,new MedianBlurFilter())
                        }, new GrabBySize(), new CleanByContours()))
                    .SetSudokuGrabber(
                        Builders.NewBaseSudokuGrabberBuilder()
                            .SetCalcContours(new GetContours())
                            .SetCalcHull(new GetHull())
                            .SetCalcContours(new GetCorners())
                            .SetPerspectiveWrap(new StaticPerspectiveWrap())
                            .SetPreSudokuGrabFilters(new List<IFilter>
                            {
                                new GrayFilter(),
                                new AdaptiveThresholdFilter(),
                                new FastDeNoisingFilter()
                            })
                            .GetGrabber()
                    )
                    .GetSolver()
                );
        }
    }
}
