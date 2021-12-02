// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using AdventOfCode2019.Day2;

#endregion

namespace AdventOfCode.Y2019.Day2
{
    public class Day02_2 : IPuzzle
    {
        public void Run()
        {
            var input = File
                .ReadAllText(Path.Combine("Y2019", "Day2", "PuzzleInput.txt"))
                .Split(",")
                .Select(int.Parse);

            var result = CalculateResult(input);
            Console.WriteLine($"2019 - Day 2/2: {result}");
        }

        private static int CalculateResult(IEnumerable<int> input)
        {
            return Enumerable
                .Range(0, 99)
                .SelectMany(noun =>
                    Enumerable
                        .Range(0, 99)
                        .Select(verb => new
                        {
                            noun,
                            verb,
                            output = Computer.ExecuteProgram(input.ToImmutableList(), noun, verb),
                            result = 100 * noun + verb
                        }))
                .First(result => result.output == 19690720).result;
        }
    }
}