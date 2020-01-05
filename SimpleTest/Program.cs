using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Microsoft.Extensions.DependencyInjection;
using Solver;

namespace SimpleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection();
            new Startup().ConfigureServices(serviceProvider);

            var image = CvInvoke.Imread("C:\\Users\\Daniel\\Desktop\\koty\\sudoku.jpg", ImreadModes.AnyColor);
            serviceProvider.BuildServiceProvider()
                .GetService<ISudokuSolver>()
                .Solve(image);

        }
    }
}
