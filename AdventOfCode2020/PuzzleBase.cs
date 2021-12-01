// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    public abstract class PuzzleBase : IPuzzle
    {
        public void Run()
        {
            var start = DateTime.Now;
            var result = RunPuzzle();
            Console.WriteLine($"{GetType().Name} ({DateTime.Now.Subtract(start).TotalMilliseconds:0} ms): {result}");
        }

        protected abstract string RunPuzzle();

        protected static List<string> ReadInputDataAsStringArray()
        {
            return File
                .ReadAllLines( Path.Combine("Day1", "PuzzleInput.txt"))
                .ToList();
        }
        protected static List<int> ReadInputDataAsIntegerArray()
        {
            return ReadInputDataAsStringArray()
                .Select(int.Parse)
                .ToList();
        }
    }
}