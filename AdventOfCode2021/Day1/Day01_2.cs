// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.IO;
using System.Linq;
using System.Reactive.Linq;

#endregion

namespace AdventOfCode2021.Day1
{
    public class Day01_2 : IPuzzle
    {
        public void Run()
        {
            File.ReadAllLines(Path.Combine("Day1/PuzzleInput.txt"))
                .ToObservable()
                .Select(int.Parse)
                .Buffer(3, 1)
                .Where(triple => triple.Count == 3)
                .Select(triple => triple.Sum())
                .Buffer(2, 1)
                .Where(pair => pair.Count == 2 && pair[1] > pair[0])
                .Count()
                .Subscribe(result => Console.WriteLine("Day 1/2: " + result));
        }
    }
}