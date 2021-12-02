// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using AdventOfCode2019.Day2;

#endregion

namespace AdventOfCode.Y2019.Day2
{
    public class Day02_1 : IPuzzle
    {
        public void Run()
        {
            var input = File
                .ReadAllText(Path.Combine("Y2019", "Day2", "PuzzleInput.txt"))
                .Split(",")
                .Select(int.Parse)
                .ToImmutableList();

            var result = Computer.ExecuteProgram(input, 12, 2);
            Console.WriteLine($"2019 - Day 2/1: {result}");
        }
    }
}