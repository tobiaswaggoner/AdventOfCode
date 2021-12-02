// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

#endregion

namespace AdventOfCode.Y2020.Day3
{
    public class Day03_2 : IPuzzle
    {
        public void Run()
        {
            var puzzleInput = File.ReadLines(Path.Combine("Y2020", "Day3", "PuzzleInput.txt")).ToList();

            var result = new List<Slope> { new(1, 1), new(3, 1), new(5, 1), new(7, 1), new(1, 2) }
                .Select(slope => CalculateTreesForSlope(puzzleInput, slope))
                .Aggregate(1, (result, next) => result * next);

            Console.WriteLine($"2020 - Day 3/2: {result}");
        }

        private static int CalculateTreesForSlope(List<string> puzzleInput, Slope slope)
        {
            return puzzleInput
                .Select((s, i) => new { LineNumber = i, Line = s })
                .Where(step => step.LineNumber % slope.Down == 0)
                .Select(step => step.Line[step.LineNumber / slope.Down * slope.Right % step.Line.Length] == '#' ? 1 : 0)
                .Sum();
        }

        private record Slope(int Right, int Down);
    }
}