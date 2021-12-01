// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System.Collections.Generic;
using System.Linq;

#endregion

namespace AdventOfCode2019.Day1
{
    public class Day01_1 : PuzzleBase
    {
        protected override string RunPuzzle()
        {
            var input = ReadInputDataAsIntegerArray("Day1");
            var result = CalculateResult(input);
            return $"Result: {result}";
        }

        private static int CalculateResult(IReadOnlyList<int> input)
        {
            return input
                .Select(i => i / 3 - 2)
                .Sum();
        }
    }
}