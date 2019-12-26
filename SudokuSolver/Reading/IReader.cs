namespace SudokuSolver.Reading
{
    public interface IReader<out T>
    {
        T Read(string filename);
    }
}