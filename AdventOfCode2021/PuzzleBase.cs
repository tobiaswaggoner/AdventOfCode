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

        protected static List<string> ReadInputDataAsCommaSeparatedStringArray(string dir)
        {
            return File
                .ReadAllText( Path.Combine(dir, "PuzzleInput.txt"))
                .Split(",")
                .Select( t => t.Trim())
                .ToList();
        }
        protected static List<string> ReadInputDataAsStringArray(string dir)
        {
            return File
                .ReadAllLines( Path.Combine(dir, "PuzzleInput.txt"))
                .ToList();
        }
        protected static List<int> ReadInputDataAsIntegerArray(string dir)
        {
            return ReadInputDataAsStringArray(dir)
                .Select(int.Parse)
                .ToList();
        }
        protected static List<int> ReadInputDataAsCommaSeparatedIntegerArray(string dir)
        {
            return ReadInputDataAsCommaSeparatedStringArray(dir)
                .Select(int.Parse)
                .ToList();
        }
    }
}