using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SudokuSolver.Model;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.ViewModel.Solving;

namespace UnitTests.ViewModel.Solving
{
    [TestFixture()]
    public class SolvingStrategyTests
    {
        private static readonly object[] SudokuList = {
            new object[]
            {
              new[,]{
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
                new[,]{
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
                new[,]{
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
                new[,]{
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

        private static readonly object[] InvalidSudokuList = {
            new object[]
            {
                new[,]{
                    {3,4,0,0,0,8,0,0,0},
                    {0,0,7,0,0,1,8,0,0},
                    {0,8,9,5,0,0,4,2,0},
                    {0,0,6,0,0,0,9,0,3},
                    {0,2,0,0,0,0,0,8,0},
                    {4,0,8,0,0,0,2,0,0},
                    {0,1,3,0,0,7,6,4,0},
                    {0,0,5,8,0,0,7,0,0},
                    {0,0,0,1,0,0,0,9,8},
                }
            }
        };

        [Test]
        [TestCaseSource(nameof(SudokuList))]
        public void BacktrackingStrategyTests(int[,] data)
        {
            var sudoku = new List<List<Cell>>();
            for (var i = 0; i < 9; i++)
            {
                var nextList = new List<Cell>();
                sudoku.Add(nextList);
                for (var j = 0; j < 9; j++)
                {
                    var value = data[i, j];
                    nextList.Add(new Cell(value, value == 0 ? State.Unset : State.InitialSet));
                }
            }

            var solver = new BacktrackingStrategy();
            var result = solver.Solve(sudoku);

            Assert.IsTrue(result,"Result:");
            Assert.IsFalse(sudoku.SelectMany(x => x).Any(x => x.Value == 0),"Any zero:");
            Assert.IsTrue(SudokuValidator.IsValid(sudoku),"Valid: ");
        }

        [Test]
        [TestCaseSource(nameof(SudokuList))]
        public void PreSolvingStrategyTest(int[,] data)
        {
            var sudoku = new List<List<Cell>>();
            for (var i = 0; i < 9; i++)
            {
                var nextList = new List<Cell>();
                sudoku.Add(nextList);
                for (var j = 0; j < 9; j++)
                {
                    var value = data[i, j];
                    nextList.Add(new Cell(value, value == 0 ? State.Unset : State.InitialSet));
                }
            }

            var solver = new PreSolvingStrategy();
            var result = solver.Solve(sudoku);

            Assert.IsTrue(result, "Result:");
            Assert.IsFalse(sudoku.SelectMany(x => x).Any(x => x.Value == 0), "Any zero:");
            Assert.IsTrue(SudokuValidator.IsValid(sudoku), "Valid: ");
        }

        [Test]
        [TestCaseSource(nameof(InvalidSudokuList))]
        public void BacktrackingStrategyInValidTests(int[,] data)
        {
            var sudoku = new List<List<Cell>>();
            for (var i = 0; i < 9; i++)
            {
                var nextList = new List<Cell>();
                sudoku.Add(nextList);
                for (var j = 0; j < 9; j++)
                {
                    var value = data[i, j];
                    nextList.Add(new Cell(value, value == 0 ? State.Unset : State.InitialSet));
                }
            }

            var solver = new BacktrackingStrategy();
            var result = solver.Solve(sudoku);

            Assert.IsFalse(result, "Result:");
        }

        [Test]
        [TestCaseSource(nameof(InvalidSudokuList))]
        public void PreSolvingStrategyInValidTest(int[,] data)
        {
            var sudoku = new List<List<Cell>>();
            for (var i = 0; i < 9; i++)
            {
                var nextList = new List<Cell>();
                sudoku.Add(nextList);
                for (var j = 0; j < 9; j++)
                {
                    var value = data[i, j];
                    nextList.Add(new Cell(value, value == 0 ? State.Unset : State.InitialSet));
                }
            }

            var solver = new PreSolvingStrategy();
            var result = solver.Solve(sudoku);

            Assert.IsFalse(result, "Result:");
          
        }
    }
}