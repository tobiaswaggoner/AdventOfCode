// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.IO;
using System.Linq;
using System.Reactive.Linq;

#endregion

namespace AdventOfCode.Y2021.Day3
{
    public class Day03_1 : IPuzzle
    {
        public void Run()
        {
            File.ReadAllLines(Path.Combine("Y2021", "Day3", "PuzzleInput.txt"))
                .ToObservable()
                .Aggregate( new int[12], (counts, s) =>
                {
                    s.Select((c, index) => new { c, index})
                        .ToList()
                        .ForEach( ci => counts[ci.index] += ci.c == '1' ? 1 : 0);
                    return counts;
                } )
                .Select( counts => counts.Aggregate( "", (result, count) => $"{result}{(count>500 ? "1" : "0")}" ))
                .Select( gammaString => Convert.ToInt32(gammaString, 2))
                .Select( gamma => gamma * (~gamma & 0xfff) )
                .Subscribe(result => Console.WriteLine($"2021 - Day 3/1: {result}"));
        }
    }
}