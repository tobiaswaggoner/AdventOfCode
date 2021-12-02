// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.IO;
using System.Reactive.Linq;

#endregion

namespace AdventOfCode2020.Day1
{
    public class Day01_1 : IPuzzle
    {
        public void Run()
        {
            var input = File.ReadAllLines(Path.Combine("Day1", "PuzzleInput.txt"))
                .ToObservable()
                .Select(int.Parse);
            input.SelectMany(a => input.Select(b => new { a, b, sum = a + b, product = a * b }))
                .Where(result => result.sum == 2020)
                .Take(1)
                .Subscribe(result => Console.WriteLine("Day 1/1: " + result.product));
        }
    }
}