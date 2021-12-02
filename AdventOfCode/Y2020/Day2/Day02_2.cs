// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.IO;
using System.Reactive.Linq;
using GrokNet;

#endregion

namespace AdventOfCode.Y2020.Day2
{
    public class Day02_3 : IPuzzle
    {
        public void Run()
        {
            var grok = new Grok("%{INT:min}-%{INT:max} %{WORD:character}: %{WORD:password}");

            File.ReadAllLines(Path.Combine("Y2020", "Day2", "PuzzleInput.txt"))
                .ToObservable()
                .Select(grok.Parse)
                .Select(pattern => new
                {
                    min = int.Parse((string)pattern[0].Value),
                    max = int.Parse((string)pattern[1].Value),
                    character = ((string)pattern[2].Value)[0],
                    password = (string)pattern[3].Value
                })
                .Count(criteria =>
                    (criteria.password[criteria.min - 1] == criteria.character) ^
                    (criteria.password[criteria.max - 1] == criteria.character))
                .Subscribe(result => Console.WriteLine($"2020 - Day 2/2: {result}"));
        }
    }
}