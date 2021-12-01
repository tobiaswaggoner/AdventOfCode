﻿// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System.Collections.Generic;

#endregion

namespace AdventOfCode2019.Day3
{
    public class Day03_1 : PuzzleBase
    {
        protected override string RunPuzzle()
        {
            var input = ReadInputDataAsStringArray("Day3");
            var result = CalculateResult(input);
            return $"Result: {result}";
        }

        private static int CalculateResult(IReadOnlyList<string> input)
        {
            return CrossWireCalculator.DistanceToClosestCrossing(input[0], input[1]);
        }
    }
}