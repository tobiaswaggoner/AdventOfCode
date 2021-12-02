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

namespace AdventOfCode2020
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
                .Where(t => t.GetInterface(nameof(IPuzzle))!=null)
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
                .Where(t => t.GetInterface(nameof(IPuzzle))!=null)
                .OrderBy(t => t.Name)
                .Select(t => (IPuzzle)Activator.CreateInstance(t))
                .ToList();

            allPuzzles.ForEach( puzzle =>
            {
                var start = DateTime.Now;
                puzzle.Run();
                Console.WriteLine($"    ... {DateTime.Now.Subtract(start).TotalMilliseconds:0}ms");
            });
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