using System.IO;

namespace SudokuSolver.ViewModel.Reading
{
    public class FileReader : IReader<string>
    {
        public string Read(string filename)
        {
            return File.ReadAllText(filename);
        }
    }
}