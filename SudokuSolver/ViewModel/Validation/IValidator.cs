namespace SudokuSolver.ViewModel.Validation
{
    public interface IValidator
    {
        bool Validate(string filename);
    }
}