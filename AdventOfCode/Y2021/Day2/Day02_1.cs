// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.IO;
using System.Reactive.Linq;

#endregion

namespace AdventOfCode.Y2021.Day2
{
    public class Day02_1 : IPuzzle
    {
        public void Run()
        {
            File.ReadAllLines(Path.Combine("Y2021", "Day2", "PuzzleInput.txt"))
                .ToObservable()
                .Select(cmd =>
                {
                    var parts = cmd.Split(' ');
                    return new { direction = parts[0], distance = int.Parse(parts[1]) };
                })
                .Aggregate(new { depth = 0, position = 0 }, (pos, cmd) =>
                    new
                    {
                        depth = pos.depth + cmd.direction switch
                        {
                            "up" => -cmd.distance,
                            "down" => cmd.distance,
                            _ => 0
                        },
                        position = pos.position + cmd.direction switch
                        {
                            "forward" => cmd.distance,
                            _ => 0
                        }
                    })
                .Subscribe(result => Console.WriteLine($"2021 - Day 2/1: {result.depth * result.position}"));
        }
    }
}