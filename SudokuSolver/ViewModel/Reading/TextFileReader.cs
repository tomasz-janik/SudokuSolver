using System.IO;

namespace SudokuSolver.ViewModel.Reading
{
    public class TextFileReader : IReader<string>
    {
        public string Read(string filename)
        {
            return File.ReadAllText(filename);
        }
    }
}