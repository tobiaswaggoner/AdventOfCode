// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using GrokNet;

#endregion

namespace AdventOfCode2020.Day3
{
    public class Day03_1 : IPuzzle
    {
        public void Run()
        {
            File.ReadLines(Path.Combine("Day3", "PuzzleInput.txt"))
                .ToObservable()
                .Zip( Observable.Range(0, int.MaxValue), (s, i) => new { LineNumber= i, Line=s })
                .Select( step => step.Line[step.LineNumber * 3 % step.Line.Length] == '#' ? 1 : 0)
                .Sum()
                .Subscribe(result => Console.WriteLine($"Day 3/1: {result}"));
        }
    }
}