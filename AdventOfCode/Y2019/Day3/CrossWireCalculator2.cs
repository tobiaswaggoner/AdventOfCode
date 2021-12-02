// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.Collections.Immutable;
using System.Linq;

#endregion

namespace AdventOfCode.Y2019.Day3
{
    public record Instruction(string Direction, int Distance);

    public record Point(int X, int Y);

    public static class CrossWireCalculator
    {
        public static int FewestStepsToReachAnyCrossing(string wireInput1, string wireInput2)
        {
            var wirePositions1 = CalculateWirePositions(wireInput1);
            var wirePositions2 = CalculateWirePositions(wireInput2);
            var intersections = wirePositions1
                .Intersect(wirePositions2);

            var distances = intersections
                .Select(point => wirePositions1.TakeWhile(p => p != point).Count()
                                 + wirePositions2.TakeWhile(p => p != point).Count());

            var minDistance = distances
                .Where(distance => distance > 0)
                .Min();

            return minDistance;
        }

        public static int DistanceToClosestCrossing(string wireInput1, string wireInput2)
        {
            var wirePositions1 = CalculateWirePositions(wireInput1);
            var wirePositions2 = CalculateWirePositions(wireInput2);
            var intersections = wirePositions1
                .Intersect(wirePositions2);

            var distances = intersections
                .Select(point => Math.Abs(point.X) + Math.Abs(point.Y));

            var minDistance = distances
                .Where(distance => distance > 0)
                .Min();
            return minDistance;
        }

        private static ImmutableList<Point> CalculateWirePositions(string wireInput)
        {
            var instructions = wireInput.Split(",")
                .Select(inp => new Instruction(inp[..1], int.Parse(inp[1..])));

            return instructions.Aggregate(ImmutableList<Point>.Empty.Add(new Point(0, 0)), DrawWire);
        }

        private static ImmutableList<Point> DrawWire(ImmutableList<Point> currentPath, Instruction nextInstruction)
        {
            var (direction, distance) = nextInstruction;
            var deltaX = GetDeltaX(direction);
            var deltaY = GetDeltaY(direction);

            var (lastX, lastY) = currentPath.Last();

            return currentPath.AddRange(Enumerable.Range(1, distance)
                .Select(p => new Point(lastX + deltaX * p,
                    lastY + deltaY * p)));
        }

        private static int GetDeltaX(string direction)
        {
            return direction switch
            {
                "U" => 0,
                "D" => 0,
                "R" => 1,
                "L" => -1,
                _ => throw new ApplicationException($"Unexpected Direction {direction}"),
            };
        }

        private static int GetDeltaY(string direction)
        {
            return direction switch
            {
                "U" => -1,
                "D" => 1,
                "R" => 0,
                "L" => 0,
                _ => throw new ApplicationException($"Unexpected Direction {direction}"),
            };
        }
    }
}