using System;
using System.Globalization;
using NUnit.Framework;
using SudokuSolver.ViewModel.Converting;

namespace UnitTests.ViewModel
{
    public class DigitConverterTest
    {
        [TestCase("1", 1)]
        [TestCase("9", 9)]
        [TestCase("4", 4)]
        public void ValidConvertBackTest(object input, int? output)
        {
            var result = new DigitConverter()
                .ConvertBack(input, Type.GetType("int"), null, CultureInfo.CurrentCulture);
            
            Assert.AreEqual(output, result);
        }
        
        [TestCase("", null)]
        public void InvalidConvertBackTest(object input, int? output)
        {
            var result = new DigitConverter()
                .ConvertBack(input, Type.GetType("int"), null, CultureInfo.CurrentCulture);
            
            Assert.AreEqual(output, result);
        }
    }
}