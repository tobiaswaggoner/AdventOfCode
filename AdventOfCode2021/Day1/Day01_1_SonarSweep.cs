// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System.Collections.Generic;
using System.Linq;

#endregion

namespace AdventOfCode2021.Day1
{
    public class Day01_1_SonarSweep : PuzzleBase
    {
        protected override string RunPuzzle()
        {
            var depths = ReadInputDataAsIntegerArray();
            var increaseCount = CalculateIncreaseCount(depths);
            return $"The measurement increased {increaseCount} times";
        }

        private static int CalculateIncreaseCount(IReadOnlyList<int> depths)
        {
            var increaseCount = depths
                .Skip(1)
                .Aggregate(
                    new Summary(0, depths[0]),
                    (result, next) => result with
                    {
                        IncreaseCount = next > result.Previous ? result.IncreaseCount + 1 : result.IncreaseCount,
                        Previous = next
                    }
                ).IncreaseCount;
            return increaseCount;
        }
    }
}