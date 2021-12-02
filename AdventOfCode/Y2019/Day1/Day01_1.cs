// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.IO;
using System.Reactive.Linq;

#endregion

namespace AdventOfCode.Y2019.Day1
{
    public class Day01_1 : IPuzzle
    {
        public void Run()
        {
            File.ReadAllLines(Path.Combine("Y2019", "Day1", "PuzzleInput.txt"))
                .ToObservable()
                .Select(int.Parse)
                .Select(i => i / 3 - 2)
                .Sum()
                .Subscribe(result => Console.WriteLine($"2019 - Day 1/1: {result} "));
        }
    }
}