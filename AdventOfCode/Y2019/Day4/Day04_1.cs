// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

#endregion

namespace AdventOfCode.Y2019.Day4
{
    public class Day04_1 : IPuzzle
    {
        public void Run()
        {
            var result = Enumerable.Range(124075, 580769 - 124075)
                .Select(ValidatePassword)
                .Sum();

            Console.WriteLine($"2019 - Day 4/1: {result}");
        }

        private int ValidatePassword(int password)
        {
            return password
                .ToString()
                .ToObservable()
                .Buffer(2, 1)
                .Where(pair => pair.Count == 2)
                .Select(pair => new { sameDigits = pair[0] == pair[1], decrease = pair[1] < pair[0] })
                .Aggregate(new { HasSameDigits = false, HasDecrease = false },
                    (result, pair) => new
                    {
                        HasSameDigits = result.HasSameDigits || pair.sameDigits,
                        HasDecrease = result.HasDecrease || pair.decrease
                    })
                .Select(result => result.HasSameDigits && !result.HasDecrease ? 1 : 0)
                .Select(result =>
                {
                    if (result == 1) Console.WriteLine($"{password}");
                    return result;
                })
                .ToTask()
                .Result;
        }
    }
}