using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using NUnit.Framework;
using SudokuGrabber;
using SudokuGrabber.Builders;
using SudokuGrabber.Filters;
using SudokuGrabber.Grabber.Digit.Strategies;
using SudokuGrabber.Models;
using SudokuGrabber.OpenCV;
using SudokuGrabber.OpenCV.Interfaces;
using SudokuGrabber.Recognizer.Strategies;

namespace IntegrationTests
{
    public class SudokuGrabberTest
    {
      
        [Test]
        public void TestAll()
        {

            // arrange

            
            var sudokuPositionGrabber = Builders.NewBaseSudokuGrabberBuilder()
                .SetCalcContours(new GetContours())
                .SetCalcHull(new GetHull())
                .SetCalcCorners(new GetCorners())
                .SetPerspectiveWrap(new StaticPerspectiveWrap(600))
                .SetPreSudokuGrabFilters(new List<IFilter>
                {
                    new GrayFilter(),
                    new FastDeNoisingFilter(100, 5, 5),
                    new AdaptiveThresholdFilter(),
                    
                })
                .GetGrabber();


            var digitRecognizer = Builders.NewBaseDigitRecognizerBuilder().SetPreDigitRecognizeFilters(
                    new List<IFilter>()
                    {
                        new CenterImage(28),
                        new DeskewImage(28)
                    })
                .SetRecognizer(new MulticlassClassification())
                .GetDigitRecognizer();

            var digitGrabber = Builders.NewStaticSizeDigitGrabber()
                .SetDigitCleanStrategy(new CleanByContours(new GetContours()))
                .SetDigitGrabStrategy(new GrabBySize())
                .SetPreDigitGrabFilters(new List<IFilter>()
                {
                    new CLeanLineImage(new GrayFilter() ,new MedianBlurFilter(3))
                })
                .GetGrabber();


            var sudokuGrabber = Builders.NewGrabberBuilder()
                .SetSudokuGrabber(sudokuPositionGrabber)
                .SetDigitGrabber(digitGrabber)
                .SetDigitRecognizer(digitRecognizer)
                .GetSolver();

            var basePath = Path.Combine(System.IO.Path.GetFullPath(@"..\..\..\"), "Resources", "TestImages");


            double correctness = 0.0f;
            int greaterThan90 = 0;
            int full = 0;
           
            for (int i = 0; i < 156; i++)
            {
                // act
                var filePath = Path.Combine(basePath, i + ".jpg");

                if (!File.Exists(filePath))
                {
                    filePath = Path.Combine(basePath, i + ".PNG");
                }

                var sudokuResult = sudokuGrabber.Grab(filePath);
                var sudokuExpected = GetFromData(Path.Combine(basePath, i + ".dat"));


                // assert
                using var resultEnumerator = sudokuResult.GetEnumerator();
                using var expectedEnumerator = sudokuExpected.GetEnumerator();
                int correct = 0;
                int correctWithoutEmpty = 0;
                int expectedWithoutEmpty = 0;

                do
                {
                    if (expectedEnumerator.Current != 0)
                    {
                        expectedWithoutEmpty++;
                    }


                    if (resultEnumerator.Current == expectedEnumerator.Current)
                    {
                        correct++;

                        if (resultEnumerator.Current != 0)
                        {
                            correctWithoutEmpty++;
                        }
                    }
                    
                    expectedEnumerator.MoveNext();
                } while (resultEnumerator.MoveNext());


                var result = correct / 81.0;
                if (correct == 81)
                {
                    full++;
                }

                if (result >=0.9)
                {
                    greaterThan90++;
                }

                correctness += result;
            }

            Console.WriteLine($"greaterThan90: {greaterThan90}");
            Console.WriteLine($"full: {full}");
            Console.WriteLine($"correctness: {correctness}");
            Assert.GreaterOrEqual(greaterThan90 / 156.0,  0.9,  "The minimum  90 % efficiency of correct sudoku recognition  is 90%");
            Assert.GreaterOrEqual(full / 156.0, 0.5, "The minimum of fully correct sudoku recognition  is 50%");
            Assert.GreaterOrEqual(correctness / 156.0, 0.9, "The minimum average result is 90%");
        }

        private Sudoku<int> GetFromData(string path)
        {
            var result = new Sudoku<int>();
            var enumerator = (SudokuEnumerator<int>)result.GetEnumerator();

            using (var stream = new StreamReader(path))
            {
                while (!stream.EndOfStream)
                {
                    var sign = (char)stream.Read();
                    if (sign == '.')
                    {
                        enumerator.SetValue(0);
                        enumerator.MoveNext();
                    }
                    else if (Int32.TryParse(sign.ToString(), out var parse))
                    {
                        enumerator.SetValue(parse);
                        enumerator.MoveNext();
                    }
                }
             
            }

            return result;
        }
    }
}