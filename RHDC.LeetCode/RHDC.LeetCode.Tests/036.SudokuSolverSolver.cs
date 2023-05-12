using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RHDC.LeetCode.Tests
{
    [TestClass]
    public class SudokuSolver
    {
        //        Write a program to solve a Sudoku puzzle by filling the empty cells.

        //A sudoku solution must satisfy all of the following rules:

        //Each of the digits 1-9 must occur exactly once in each row.
        //Each of the digits 1-9 must occur exactly once in each column.
        //Each of the digits 1-9 must occur exactly once in each of the 9 3x3 sub-boxes of the grid.
        //The '.' character indicates empty cells.

        [TestMethod]
        public void Can_We_Get_A_Value_From_Multi_Dimensional_Array()
        {
            int?[,] mda = new int?[9, 9] { { 5, 3, 4, 6, 7, 8, 9, 1, 2 }, { 6, 7, 2, 1, 9, 5, 3, 4, 8 }, { 1, 9, 8, 3, 4, 2, 5, 6, 7 }, { 8, 5, 9, 7, 6, 1, 4, 2, 3 }, { 4, 2, 6, 8, 5, 3, 7, 9, 1 }, { 7, 1, 3, 9, 2, 4, 8, 5, 6 }, { 9, 6, 1, 5, 3, 7, 2, 8, 4 }, { 2, 8, 7, 4, 1, 9, 6, 3, 5 }, { 3, 4, 5, 2, 8, 6, 1, 7, 9 } };

            var expectedValue = 5;
            var selectedValue = mda[4, 4];

            Assert.AreEqual(expectedValue, selectedValue);
        }

        [TestMethod]
        public void Can_We_Get_Block_Number_Values_From_Multi_Dimensional_Array_When_Given_A_Value()
        {
            int?[,] mda = new int?[9, 9] { { 5, 3, 4, 6, 7, 8, 9, 1, 2 }, { 6, 7, 2, 1, 9, 5, 3, 4, 8 }, { 1, 9, 8, 3, 4, 2, 5, 6, 7 }, { 8, 5, 9, 7, 6, 1, 4, 2, 3 }, { 4, 2, 6, 8, 5, 3, 7, 9, 1 }, { 7, 1, 3, 9, 2, 4, 8, 5, 6 }, { 9, 6, 1, 5, 3, 7, 2, 8, 4 }, { 2, 8, 7, 4, 1, 9, 6, 3, 5 }, { 3, 4, 5, 2, 8, 6, 1, 7, 9 } };

            var rowNumber = 4;
            var columnNumber = 4;
            var value = mda[rowNumber, columnNumber].Value;

            var blockNumber = GetBlockNumberByCoordinates(rowNumber, columnNumber);
            // Column # =>   0, 1, 2        3, 4, 5        6, 7, 8
            // Row 0 = //0//{0}{1}{2} //1//{0}{1}{2} //2//{0}{1}{2}
            // Row 1 = //0//{3}{4}{5} //1//{3}{4}{5} //2//{3}{4}{5}
            // Row 2 = //0//{6}{7}{8} //1//{6}{7}{8} //2//{6}{7}{8}

            // Row 3 = //3//{0}{1}{2} //4//{0}{1}{2} //5//{0}{1}{2}
            // Row 4 = //3//{3}{4}{5} //4//{3}{4}{5} //5//{3}{4}{5}
            // Row 5 = //3//{6}{7}{8} //4//{6}{7}{8} //5//{6}{7}{8}

            // Row 6 = //6//{0}{1}{2} //7//{0}{1}{2} //8//{0}{1}{2}
            // Row 7 = //6//{3}{4}{5} //7//{3}{4}{5} //8//{3}{4}{5}
            // Row 8 = //6//{6}{7}{8} //7//{6}{7}{8} //8//{6}{7}{8}

            //var coordinatesToRead = new int[] { }

            // Question: Should we include the original value in the expected list?
            //var expectedValues = new int[] { 7, 6, 1, 8, 5, 3, 9, 2, 4 };
            var blockValues = new int?[] { mda[blockNumber, 0].Value, mda[blockNumber, 1].Value, mda[blockNumber, 2].Value, mda[blockNumber, 3].Value, mda[blockNumber, 4].Value, mda[blockNumber, 5].Value, mda[blockNumber, 6].Value, mda[blockNumber, 7].Value, mda[blockNumber, 8].Value };
            var expectedValues = new int?[]  { 4, 2, 6, 8, 5, 3, 7, 9, 1 } ;

            var areArraysEqual = Enumerable.SequenceEqual(expectedValues, blockValues.ToArray());

            Assert.IsTrue(areArraysEqual);
        }

        [TestMethod]
        public void Can_We_Get_A_Row_Values_From_Multi_Dimensional_Array()
        {

            int?[,] boardState = new int?[9, 9] { { 5, 3, null, null, 7, null, null, null, null }, { 6, null, null, 1, 9, 5, null, null, null }, { null, 9, 8, null, null, null, null, 6, null }, { 8, null, null, null, 6, null, null, null, 3 }, { 4, null, null, 8, null, 3, null, null, 1 }, { 7, null, null, null, 2, null, null, null, 6 }, { null, 6, null, null, null, null, 2, 8, null }, { null, null, null, 4, 1, 9, null, null, 5 }, { null, null, null, null, 8, null, null, 7, 9 } };

            var rowNumber = 0;
            var expectedValues = new int?[] { 5, 3, null, null, 7, null, null, null, null };
            //var foo = boardState[0, 0];
            var rowValues = new int?[9];
            for (int i = 0; i < 9; i++)
            {
                rowValues[i] = boardState[rowNumber, i];
            }

            var areArraysEqual = Enumerable.SequenceEqual(expectedValues, rowValues);
            Assert.IsTrue(areArraysEqual);
        }

        [TestMethod]
        public void Can_We_Get_A_Column_Values_From_Multi_Dimensional_Array()
        {
            int?[,] mda = new int?[9, 9] { { 5, 3, 4, 6, 7, 8, 9, 1, 2 }, { 6, 7, 2, 1, 9, 5, 3, 4, 8 }, { 1, 9, 8, 3, 4, 2, 5, 6, 7 }, { 8, 5, 9, 7, 6, 1, 4, 2, 3 }, { 4, 2, 6, 8, 5, 3, 7, 9, 1 }, { 7, 1, 3, 9, 2, 4, 8, 5, 6 }, { 9, 6, 1, 5, 3, 7, 2, 8, 4 }, { 2, 8, 7, 4, 1, 9, 6, 3, 5 }, { 3, 4, 5, 2, 8, 6, 1, 7, 9 } };

            var expectedValues = new int[] { 5, 6, 1, 8, 4, 7, 9, 2, 3 };
            var values = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                var valueToAdd = mda[i, 0].Value;
                values.Add(valueToAdd);
            }

            var areArraysEqual = Enumerable.SequenceEqual(expectedValues, values.ToArray());

            Assert.IsTrue(areArraysEqual);
        }

        [TestMethod]
        public void Can_We_Solve_Test_Case_One()
        {
            int?[,] boardState = new int?[9, 9] { { 5, 3, null, null, 7, null, null, null, null }, { 6, null, null, 1, 9, 5, null, null, null }, { null, 9, 8, null, null, null, null, 6, null }, { 8, null, null, null, 6, null, null, null, 3 }, { 4, null, null, 8, null, 3, null, null, 1 }, { 7, null, null, null, 2, null, null, null, 6 }, { null, 6, null, null, null, null, 2, 8, null }, { null, null, null, 4, 1, 9, null, null, 5 }, { null, null, null, null, 8, null, null, 7, 9 } };

            var solvedBoard = Solve(boardState);

            int?[,] expectedSolvedBoardState = new int?[9, 9] { { 5, 3, 4, 6, 7, 8, 9, 1, 2 }, { 6, 7, 2, 1, 9, 5, 3, 4, 8 }, { 1, 9, 8, 3, 4, 2, 5, 6, 7 }, { 8, 5, 9, 7, 6, 1, 4, 2, 3 }, { 4, 2, 6, 8, 5, 3, 7, 9, 1 }, { 7, 1, 3, 9, 2, 4, 8, 5, 6 }, { 9, 6, 1, 5, 3, 7, 2, 8, 4 }, { 2, 8, 7, 4, 1, 9, 6, 3, 5 }, { 3, 4, 5, 2, 8, 6, 1, 7, 9 } };

            Assert.AreEqual(expectedSolvedBoardState, solvedBoard);
        }

        public int?[,] Solve(int?[,] boardState)
        {
            for (int x = 1; x < 10; x++)
            {
                for (int y = 1; y < 10; y++)
                {
                    if (boardState[x, y] == null)
                    {
                        for (int n = 1; n < 10; n++)
                        {
                            if (IsPossible(boardState, x, y, n))
                            {
                                boardState[x, y] = n;
                                Solve(boardState);
                                boardState[x, y] = null;
                            }
                        }
                    }
                }
            }

            return boardState;
        }

        public bool IsPossible(int?[,] boardState, int x, int y, int n)
        {
            // check the row
            var rowInts = new int[] { };
            if (rowInts.Any(z => z == x))
            {
                return false;
            }
            // check the column
            var columnInts = new int[] { };
            if (columnInts.Any(z => z == x))
            {
                return false;
            }
            // check the grid
            var gridInts = new int[] { };
            if (gridInts.Any(z => z == x))
            {
                return false;
            }

            return true;
        }

        // Grouping
        // *Values = 1-2-3-4-5-6-7-8-9
        // Positioning [9]
        // Set Position

        // Step #1: Is grouping valid on its own?

        // We have a grouping, intake a new value with coordinates, see if the new value exists in *Values, If not, it is invalid. If it is, set the position, remove the value from *Values

        // Step #2: Is grouping valid as a board? If so, Find Solution

        // ## Grid
        //[[1,2,3]
        //[4,5,6]
        //[7,8,9]]

        // ## Row
        // [[1,2,3][4,5,6][7,8,9]]

        // ## Column
        //[[1]
        //[2]
        //[3]
        //[4]
        //[5]
        //[6]
        //[7]
        //[8]
        //[9]]

        private static int GetBlockNumberByCoordinates(int x, int y)
        {
            return (int)(Math.Floor((Double)y / 3) + (Math.Floor((Double)x / 3) * 3));
        }

        [TestMethod]
        public void Does_Rexs_Method_Actually_Work()
        {
            var rowNumber = 4;
            var columnNumber = 1;
            var actual = GetBlockNumberByCoordinates(rowNumber, columnNumber);
            var expected = 3;
            Assert.AreEqual(expected, actual);

            rowNumber = 8;
            columnNumber = 8;
            actual = GetBlockNumberByCoordinates(rowNumber, columnNumber);
            expected = 8;
            Assert.AreEqual(expected, actual);
        }
    }
}