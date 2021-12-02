// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

#endregion

namespace AdventOfCode
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            WriteIntro();

            ExecuteAllPuzzles(2021);

            WriteOutro();
        }

        private static void ExecuteAllPuzzles(int? year = null, int? day=null, int? puzzleNo = null )
        {
            Console.WriteLine("Running all puzzles...");

            var allPuzzles = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterface(nameof(IPuzzle)) != null)
                .Where(t=> 
                    (year == null || t.Namespace!.Contains(year.ToString())) 
                    && (day == null || t.Name.StartsWith($"Day{day:00}"))
                    && (puzzleNo == null || t.Name.EndsWith($"_{puzzleNo:0}"))
                    )
                .OrderBy(t => t.FullName)
                .Select(t => (IPuzzle)Activator.CreateInstance(t))
                .ToList();

            allPuzzles.ForEach(puzzle =>
            {
                var start = DateTime.Now;
                puzzle.Run();
                Console.WriteLine($"    ... {DateTime.Now.Subtract(start).TotalMilliseconds:0}ms");
            });
        }

        private static void WriteIntro()
        {
            Console.WriteLine("");
            Console.WriteLine("Advent of code");
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