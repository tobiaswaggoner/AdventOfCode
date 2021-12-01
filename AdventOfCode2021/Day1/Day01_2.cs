// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System.Collections.Generic;
using System.Linq;

#endregion

namespace AdventOfCode2021.Day1
{
    public class Day01_2 : PuzzleBase
    {
        protected override string RunPuzzle()
        {
            var depths = ReadInputDataAsIntegerArray("Day1");
            var increaseCount = CalculateIncreaseCount(depths);
            return $"The measurement increased {increaseCount} times";
        }

        private static int CalculateIncreaseCount(IReadOnlyList<int> depths)
        {
            var slidingWindows = depths
                .Select((next, index) =>
                    next
                    + (index == 0 ? 0 : depths[index - 1])
                    + (index == depths.Count - 1 ? 0 : depths[index + 1])
                )
                .Skip(1)
                .Take(depths.Count - 2)
                .ToList();

            var increaseCount = slidingWindows
                .Skip(1)
                .Aggregate(
                    new Summary(0, slidingWindows[0]),
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