// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using GrokNet;

#endregion

namespace AdventOfCode2020.Day2
{
    public class Day02_1 : IPuzzle
    {
        public void Run()
        {
            var grok = new Grok("%{INT:min}-%{INT:max} %{WORD:character}: %{WORD:password}");
            
            File.ReadAllLines(Path.Combine("Day2", "PuzzleInput.txt"))
                .ToObservable()
                .Select(grok.Parse)
                .Select(pattern => new { min = int.Parse((string)pattern[0].Value), max = int.Parse((string)pattern[1].Value), character = ((string) pattern[2].Value)[0], password = (string) pattern[3].Value })
                .Select(criteria => new { criteria.min, criteria.max, criteria.character, criteria.password, charCount = criteria.password.Count(c => c == criteria.character )})
                .Count(criteria => criteria.charCount>=criteria.min && criteria.charCount<=criteria.max)
                .Subscribe(result => Console.WriteLine($"Day 2/1: {result}"));
        }
    }
}