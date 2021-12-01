// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using AdventOfCode2021;

#endregion

namespace AdventOfCode2019.Day2
{
    public class Day02_2 : PuzzleBase
    {
        protected override string RunPuzzle()
        {
            var input = ReadInputDataAsCommaSeparatedIntegerArray("Day2");
            var result = CalculateResult(input);
            return $"Result: {result}";
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