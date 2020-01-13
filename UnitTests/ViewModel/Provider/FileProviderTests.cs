using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.ViewModel.Provider;

namespace UnitTests.ViewModel.Provider
{
    [TestFixture]
    public class FileProviderTests
    {
      
        [Test]
        public void TestExtension()
        {
          
            var oneExtProvider = new Mock<ISpecificProvider>();
            var twoExtProvider = new Mock<ISpecificProvider>();

            var twoExtOut = new List<List<Cell>>();
            var oneExtOut = new List<List<Cell>>();

            oneExtProvider.Setup(p => p.GetExtension()).Returns(".test");
            twoExtProvider.Setup(p => p.GetExtension()).Returns(".img.txt");
            oneExtProvider.Setup(p => p.Provide(It.IsAny<string>())).Returns(oneExtOut);
            twoExtProvider.Setup(p => p.Provide(It.IsAny<string>())).Returns(twoExtOut);

            var providers = new List<ISpecificProvider>
            {
                oneExtProvider.Object,
                twoExtProvider.Object
            };

            var provider = new FileProvider(providers);
          
            Assert.AreSame(provider.Provide("img.test"),oneExtOut);
            Assert.AreSame(provider.Provide("test.txt"), twoExtOut);
            Assert.AreSame(provider.Provide("test.img"), twoExtOut);
        }

        [Test]
        public void TestNull()
        {
            var oneExtProvider = new Mock<ISpecificProvider>();
            var oneExtOut = new List<List<Cell>>();

            oneExtProvider.Setup(p => p.GetExtension()).Returns(".test");
            oneExtProvider.Setup(p => p.Provide(It.IsAny<string>())).Returns(oneExtOut);
           

            var providers = new List<ISpecificProvider>
            {
                oneExtProvider.Object
            };

            var provider = new FileProvider(providers);

            Assert.Null(provider.Provide("test.imgtest"));
            Assert.Null(provider.Provide("test.img"));
        }
    }
}