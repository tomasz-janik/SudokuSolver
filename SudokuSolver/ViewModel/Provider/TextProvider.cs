using System.Collections.Generic;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.ViewModel.Parsing;
using SudokuSolver.ViewModel.Reading;

namespace SudokuSolver.ViewModel.Provider
{
    internal class TextProvider : ISpecificProvider
    {
        private readonly Reader<string> _reader;
        private readonly Parser<string> _parser;

        public TextProvider(Reader<string> reader, Parser<string> parser)
        {
            _reader = reader;
            _parser = parser;
        }

        public string GetExtension()
        {
            return ".txt";
        }

        public List<List<Cell>> Provide(string path)
        {
            var readingResult = _reader.Read(path);
            if (string.IsNullOrEmpty(readingResult)) return default;

            var parsingResult = _parser.Parse(readingResult);
            return parsingResult;
        }
    }
}