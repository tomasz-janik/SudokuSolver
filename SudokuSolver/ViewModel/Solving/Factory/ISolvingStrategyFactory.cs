﻿namespace SudokuSolver.ViewModel.Solving.Factory
{
    public interface ISolvingStrategyFactory
    {
        ISolvingStrategy GetSolvingStrategy(string strategy);
    }
}