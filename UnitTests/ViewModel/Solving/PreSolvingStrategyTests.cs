using NUnit.Framework;
using SudokuSolver.ViewModel.Solving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SudokuSolver.Model;
using SudokuSolver.Model.Sudoku;

namespace SudokuSolver.ViewModel.Solving.Tests
{
    [TestFixture()]
    public class PreSolvingStrategyTests
    {
        private static readonly object[] _sudokuList = {
            new object[]
            {
              new int[9,9]{
                  {0,0,0,0,0,0,0,0,0},
                  {0,0,0,0,0,0,0,0,0},
                  {0,0,0,0,0,0,0,0,0},
                  {0,0,0,0,0,0,0,0,0},
                  {0,0,0,0,0,0,0,0,0},
                  {0,0,0,0,0,0,0,0,0},
                  {0,0,0,0,0,0,0,0,0},
                  {0,0,0,0,0,0,0,0,0},
                  {0,0,0,0,0,0,0,0,0},
              }
            },
            new object[]
            {
                new int[9,9]{
                    {1,0,0,0,0,0,0,0,0},
                    {0,2,0,0,0,0,0,0,0},
                    {0,0,3,0,0,0,0,0,0},
                    {0,0,0,4,0,0,0,0,0},
                    {0,0,0,0,5,0,0,0,0},
                    {0,0,0,0,0,6,0,0,0},
                    {0,0,0,0,0,0,7,0,0},
                    {0,0,0,0,0,0,0,8,0},
                    {0,0,0,0,0,0,0,0,9},
                }
            },
            new object[]
            {
                new int[9,9]{
                    {0,0,0,5,0,0,2,0,0},
                    {0,0,1,2,0,0,0,9,0},
                    {6,0,8,0,0,0,1,0,0},
                    {3,4,0,0,0,0,0,8,0},
                    {0,8,9,0,0,0,3,2,0},
                    {0,1,0,0,0,0,0,6,5},
                    {0,0,2,0,0,0,5,0,6},
                    {0,6,0,0,0,7,8,0,0},
                    {0,0,4,0,0,5,0,0,0},
                }
            }
            ,
            new object[]
            {
                new int[9,9]{
                    {9,3,6,0,0,0,2,0,0},
                    {0,0,0,0,9,3,7,4,0},
                    {0,4,0,8,2,1,0,0,9},
                    {4,7,2,0,0,0,0,0,6},
                    {0,0,0,7,5,9,0,0,0},
                    {1,0,0,0,0,0,3,7,8},
                    {5,0,0,4,1,6,0,2,0},
                    {0,2,1,3,7,0,0,0,0},
                    {0,0,4,0,0,0,0,0,0},
                }
            }
        };

        [Test()]
        [TestCaseSource("_sudokuList")]
        public void SolveTest(int[,] data)
        {
            var sudoku = new List<List<Cell>>();
            for (int i = 0; i < 9; i++)
            {
                var nextList = new List<Cell>();
                sudoku.Add(nextList);
                for (int j = 0; j < 9; j++)
                {
                    int value = data[i, j];
                    nextList.Add(new Cell(value, value == 0 ? State.Unset : State.InitialSet));
                }
            }

            var solver = new BacktrackingStrategy();
            var result = solver.Solve(sudoku);

            Assert.IsTrue(result,"Result:");
            Assert.IsFalse(sudoku.SelectMany(x => x).Any(x => x.Value == 0),"Any zero:");
            Assert.IsTrue(SudokuValidator.IsValid(sudoku),"Valid: ");
        }
    }
}