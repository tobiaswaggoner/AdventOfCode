// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System.Collections.Generic;
using System.Linq;

#endregion

namespace AdventOfCode2019.Day1
{
    public class Day01_2 : PuzzleBase
    {
        protected override string RunPuzzle()
        {
            var input = ReadInputDataAsIntegerArray("Day1");
            var result = CalculateResult(input);
            return $"Result: {result}";
            // 4985158
        }

        private static int CalculateResult(IReadOnlyList<int> input)
        {
            return input
                .Select(i => i / 3 - 2)
                .Select(fuel => CalculateAdditionalFuel(fuel, fuel))
                .Sum();
        }

        // Recursive
        private static int CalculateAdditionalFuel(int totalFuel, int additionalFuel)
        {
            var moreFuel = additionalFuel / 3 - 2;
            return moreFuel <= 0 ? totalFuel : CalculateAdditionalFuel(totalFuel + moreFuel, moreFuel);
        }

        // Or iterative
        // private static int CalculateAdditionalFuel2(int totalFuel, int additionalFuel)
        // {
        //     while (additionalFuel > 0)
        //     {
        //         totalFuel += additionalFuel;
        //         additionalFuel = (additionalFuel / 3) - 2;
        //     }
        //
        //     return totalFuel;
        // }  
    }
}