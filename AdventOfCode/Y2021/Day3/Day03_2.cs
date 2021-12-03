// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

#endregion

namespace AdventOfCode.Y2021.Day3
{
    public class Day03_2 : IPuzzle
    {
        public void Run()
        {
            var inputList = File.ReadAllLines(Path.Combine("Y2021", "Day3", "PuzzleInput.txt"))
                .ToImmutableList();

            var oxygen = FilterList(inputList, 0, true);
            var co2 = FilterList(inputList, 0, false);
            
            Console.WriteLine($"2021 - Day03_1 3/1 {oxygen} * {co2} = {oxygen * co2}");
        }

        private int FilterList(ImmutableList<string> inputList, int position, bool mostCommon)
        {
            var count1 = inputList.Count(input => input[position] == '1');
            var count0 = inputList.Count(input => input[position] == '0');

            var mostCommonChar = count1 >= count0 && count1 > 0 ? '1' : '0';
            var leastCommonChar = mostCommonChar == '1' ? '0' : '1';

            var filteredList = inputList
                .Where(input => input[position] == (mostCommon ? mostCommonChar : leastCommonChar))
                .ToImmutableList();

            if (filteredList.Count == 1) return Convert.ToInt32(filteredList[0], 2);
            if (position == 11) throw new ApplicationException("No single value found");
            return FilterList(filteredList, position + 1, mostCommon);
        }
    }
}