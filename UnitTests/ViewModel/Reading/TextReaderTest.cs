using Moq;
using NUnit.Framework;
using SudokuSolver.ViewModel.Reading;
using SudokuSolver.ViewModel.Validation;

namespace UnitTests.ViewModel.Reading
{
    [TestFixture]
    public class TextReaderTest
    {
        [Test]
        public void InvalidFilenameTest()
        {
            var textFileValidator = new TextFileValidator();
            var textFileReader = new TextFileReader();

            var parser = new TextReader(textFileValidator, textFileReader);
            var result = parser.Read("string");

            Assert.IsNull(result);
        }

        [Test]
        public void ValidFilenameTest()
        {
            var textFileValidator = new TextFileValidator();
            var textFileReader = new Mock<IReader<string>>();
            var output = new string('1', 81);

            textFileReader.Setup(e => e.Read(It.IsAny<string>())).Returns(output);

            var parser = new TextReader(textFileValidator, textFileReader.Object);
            var result = parser.Read("input.txt");
            
            Assert.AreEqual(output, result);
        }
    }
}