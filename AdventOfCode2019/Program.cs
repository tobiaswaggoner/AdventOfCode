// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

#endregion

namespace AdventOfCode2021
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            WriteIntro();
            if (args.Contains("-all") || !Debugger.IsAttached)
                ExecuteAllPuzzles();
            else
                ExecuteLatestPuzzle();
            WriteOutro();
        }

        private static void ExecuteLatestPuzzle()
        {
            Console.WriteLine("Running latest puzzle...");
            
            var puzzle = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.BaseType == typeof(PuzzleBase))
                .OrderByDescending(t => t.Name)
                .Take(1)
                .Select(t => (IPuzzle)Activator.CreateInstance(t))
                .FirstOrDefault();

            puzzle?.Run();
        }

        private static void ExecuteAllPuzzles()
        {
            Console.WriteLine("Running all puzzles...");

            var allPuzzles = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.BaseType == typeof(PuzzleBase))
                .Select(t => (IPuzzle)Activator.CreateInstance(t))
                .ToList();

            var allTasks = allPuzzles
                .Select(puzzle => Task.Run(puzzle.Run))
                .ToArray();

            Task.WaitAll(allTasks);
        }

        private static void WriteIntro()
        {
            Console.WriteLine("");
            Console.WriteLine("Advent of code 2020");
            Console.WriteLine("");
            Console.WriteLine("-------------------");
        }

        private static void WriteOutro()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("");
        }
    }
}