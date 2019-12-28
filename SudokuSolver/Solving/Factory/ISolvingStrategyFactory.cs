namespace SudokuSolver.Solving.Factory
{
    public interface ISolvingStrategyFactory
    {
        ISolvingStrategy GetSolvingStrategy(string strategy);
    }
}