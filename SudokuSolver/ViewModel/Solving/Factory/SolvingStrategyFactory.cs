using System.Collections.Generic;
using Ninject;

namespace SudokuSolver.ViewModel.Solving.Factory
{
    public class SolvingStrategyFactory : ISolvingStrategyFactory
    {
        private static readonly Dictionary<string, ISolvingStrategy> SolvingStrategies =
            new Dictionary<string, ISolvingStrategy>();

        public SolvingStrategyFactory([Named("backtracking")] ISolvingStrategy backtracking,
            [Named("pre_solving")] ISolvingStrategy preSolving)
        {
            SolvingStrategies.Add("backtracking", backtracking);
            SolvingStrategies.Add("pre_solving", preSolving);
        }

        public ISolvingStrategy GetSolvingStrategy(string strategy)
        {
            return SolvingStrategies[strategy];
        }
    }
}