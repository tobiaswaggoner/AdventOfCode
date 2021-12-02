// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.IO;
using System.Reactive.Linq;

#endregion

namespace AdventOfCode.Y2020.Day1
{
    public class Day01_2 : IPuzzle
    {
        // 85491920
        public void Run()
        {
            var input = File.ReadAllLines(Path.Combine("Y2020", "Day1", "PuzzleInput.txt"))
                .ToObservable()
                .Select(int.Parse);
            input
                .SelectMany(a =>
                    input.SelectMany(b => input.Select(c => new { a, b, c, sum = a + b + c, product = a * b * c })))
                .Where(result => result.sum == 2020)
                .Take(1)
                .Subscribe(result => Console.WriteLine("2020 - Day 1/2: " + result.product));
        }
    }
}