// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System.Collections.Generic;
using System.Collections.Immutable;

#endregion

namespace AdventOfCode2019.Day2
{
    public class Day02_1 : PuzzleBase
    {
        protected override string RunPuzzle()
        {
            var input = ReadInputDataAsCommaSeparatedIntegerArray("Day2");
            var result = CalculateResult(input);
            return $"Result: {result}";
        }

        private static int CalculateResult(IEnumerable<int> input)
        {
            return Computer.ExecuteProgram(input.ToImmutableList(), 12, 2);
        }
    }
}