// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.IO;

#endregion

namespace AdventOfCode.Y2019.Day3
{
    public class Day03_1 : IPuzzle
    {
        public void Run()
        {
            var input = File.ReadAllLines(Path.Combine("Y2019", "Day3", "PuzzleInput.txt"));
            var result = CrossWireCalculator.DistanceToClosestCrossing(input[0], input[1]);
            Console.WriteLine($"2019 - Day 3/1: {result}");
        }
    }
}