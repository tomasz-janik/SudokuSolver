using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.ViewModel.Parsing;
using SudokuSolver.ViewModel.Provider;
using SudokuSolver.ViewModel.Reading;
using SudokuSolver.ViewModel.Validation;

namespace UnitTests.ViewModel.Provider
{
    [TestFixture]
    public class TextProviderTests
    {
        [Test]
        public void ProvideValidatedTest()
        {
            var expectedResult = new List<List<Cell>>();

            var validator = new Mock<IValidator>();
            var parser = new Mock<IParser<string>>();
            var reader = new Mock<IReader<string>>();

            reader.Setup(x => x.Read(It.IsAny<string>())).Returns("test");
            validator.Setup(x => x.Validate(It.IsAny<string>())).Returns(true);
            parser.Setup(x => x.Parse(It.IsAny<string>())).Returns(expectedResult);

            var textValidator = new TextParser(validator.Object, parser.Object);
            var textReader = new TextReader(validator.Object, reader.Object);

            var textProvider = new TextProvider(textReader, textValidator);

            Assert.AreSame(expectedResult,textProvider.Provide("path"));

        }

        [Test]
        public void ProvideInValidatedTest()
        {
            var expectedResult = new List<List<Cell>>();

            var validator = new Mock<IValidator>();
            var parser = new Mock<IParser<string>>();
            var reader = new Mock<IReader<string>>();

            reader.Setup(x => x.Read(It.IsAny<string>())).Returns("test");
            validator.Setup(x => x.Validate(It.IsAny<string>())).Returns(false);
            parser.Setup(x => x.Parse(It.IsAny<string>())).Returns(expectedResult);

            var textValidator = new TextParser(validator.Object, parser.Object);
            var textReader = new TextReader(validator.Object, reader.Object);

            var textProvider = new TextProvider(textReader, textValidator);

            Assert.Null(textProvider.Provide("path"));

        }
    }
}