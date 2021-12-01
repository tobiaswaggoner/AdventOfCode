// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System.Collections.Generic;
using System.Linq;
using AdventOfCode2021;

#endregion

namespace AdventOfCode2020.Day1
{
    public class Day01_2 : PuzzleBase
    {
        protected override string RunPuzzle()
        {
            var input = ReadInputDataAsIntegerArray();
            var result = CalculateResult(input);
            return $"Result: {result}";
        }

        private static int CalculateResult(IReadOnlyList<int> input)
        {
            return input
                .SelectMany(a => input.SelectMany(b => input.Select( c => new { a, b, c, sum = a + b + c, product = a * b * c })))
                .First(result => result.sum == 2020)
                .product;
        }
    }
}