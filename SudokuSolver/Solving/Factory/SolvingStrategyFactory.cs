using System.Collections.Generic;

namespace SudokuSolver.Solving.Factory
{
    public class SolvingStrategyFactory : ISolvingStrategyFactory
    {
        //todo - can be done with reflection (https://code-maze.com/factory-method/) if we want to show we know it - imo stupid af
        //todo - better way then hardcoding strings here ? - maybe make them to finals but still ugly
        private static readonly Dictionary<string, ISolvingStrategy> SolvingStrategies =
            new Dictionary<string, ISolvingStrategy>()
            {
                //todo - pass digitfactory there
                {"backtracking", new BacktrackingStrategy(null)},
                {"dancing_lines", new DancingLinesStrategy()}
            };
        
        public ISolvingStrategy GetSolvingStrategy(string strategy)
        {
            return SolvingStrategies[strategy];
        }
    }
}