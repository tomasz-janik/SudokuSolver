﻿using SudokuSolver.Validation;

namespace SudokuSolver.Reading
{
    public class TextReader : Reader<string>
    {
        private readonly IValidator _validator;
        private readonly IReader<string> _reader;

        public TextReader(IValidator validator, IReader<string> reader)
        {
            _validator = validator;
            _reader = reader;
        }
        
        protected override bool ValidateFile(string filename)
        {
            return _validator.Validate(filename);
        }

        protected override string ReadFile(string filename)
        {
            return _reader.Read(filename);
        }
    }
}