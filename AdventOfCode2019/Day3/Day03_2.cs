﻿// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.IO;

#endregion

namespace AdventOfCode2019.Day3
{
    public class Day03_2 : IPuzzle
    {
        public void Run()
        {
            var input = File.ReadAllLines(Path.Combine("Day3", "PuzzleInput.txt"));
            var result = CrossWireCalculator.FewestStepsToReachAnyCrossing(input[0], input[1]);
            Console.WriteLine($"Day 3/1: {result}");
        }
    }
}