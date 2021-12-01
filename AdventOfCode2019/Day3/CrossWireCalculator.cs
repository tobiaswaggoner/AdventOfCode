// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

using System;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode2019.Day3
{
    public record Instruction(string Direction, int Distance);
    public record Line(int StartX, int StartY, int EndX, int EndY);
    public record Point(int X, int Y);
    
    public static class CrossWireCalculator
    {
        public static int FewestStepsToReachAnyCrossing(string wireInput1, string wireInput2)
        {
            var wireLayout1 = CalculateWirePositions(wireInput1);
            var wireLayout2 = CalculateWirePositions(wireInput2);

            var crossings = wireLayout1
                .SelectMany(line1 => wireLayout2.Select( line2 => Intersect(line1, line2) ) )
                .Where( p=> p!=null && (p.X!=0 || p.Y!=0))
                .ToImmutableList();

            var distances = crossings
                .Select(crossing => new
                {
                    Crossing = crossing, 
                    Distance1 = StepsToReachCrossing(crossing, wireLayout1),
                    Distance2 = StepsToReachCrossing(crossing, wireLayout2)
                })
                .ToImmutableList();

            var minDistance = distances.Min(crossing => crossing.Distance1 + crossing.Distance2);
            return minDistance;
        }

        private static int StepsToReachCrossing(Point crossing, ImmutableList<Line> wireLayout)
        {
            return StepsToReachCrossing(0, crossing, wireLayout, 0);
        }
        
        private static int StepsToReachCrossing(int stepsSoFar, Point crossing, ImmutableList<Line> wireLayout, int lineIndex)
        {
            var line = wireLayout[lineIndex];
            return PointIsOnLine(crossing, line) 
                ? stepsSoFar + Math.Abs(crossing.X - line.StartX) + Math.Abs(crossing.Y - line.StartY)
                : StepsToReachCrossing(
                    stepsSoFar + Math.Abs(line.EndX - line.StartX) + Math.Abs(line.EndY - line.StartY), crossing,
                    wireLayout, lineIndex + 1);
        }

        private static bool PointIsOnLine(Point crossing, Line line)
        {
            var lineStartX = Math.Min(line.StartX, line.EndX);
            var lineEndX = Math.Max(line.StartX, line.EndX);
            var lineStartY = Math.Min(line.StartY, line.EndY);
            var lineEndY = Math.Max(line.StartY, line.EndY);
            
            if (lineStartX == lineEndX && lineStartX == crossing.X && lineStartY<crossing.Y & lineEndY>crossing.Y)
            {
                return true;
            }
            if (lineStartY == lineEndY && lineStartY == crossing.Y && lineStartX<crossing.X & lineEndX>crossing.X)
            {
                return true;
            }

            return false;
        }
        
        public static int DistanceToClosestCrossing(string wireInput1, string wireInput2)
        {
            var wireLayout1 = CalculateWirePositions(wireInput1);
            var wireLayout2 = CalculateWirePositions(wireInput2);

            var crossings = wireLayout1
                .SelectMany(line1 => wireLayout2.Select( line2 => Intersect(line1, line2) ) )
                .Where( p=> p!=null && (p.X!=0 || p.Y!=0))
                .ToImmutableList();
                
            var distances = crossings
                .Select(point => Math.Abs(point.X) + Math.Abs(point.Y))
                .ToImmutableList();
                    
            var min = distances.Min();
                        
            return min;
        }

        private static Point Intersect(Line line1, Line line2)
        {
            // Parallel
            if (line1.StartX == line1.EndX && line2.StartX == line2.EndX)
                return null;
            if (line1.StartY == line1.EndY && line2.StartY == line2.EndY)
                return null;

            var line1StartX = Math.Min(line1.StartX, line1.EndX);
            var line1EndX = Math.Max(line1.StartX, line1.EndX);
            var line1StartY = Math.Min(line1.StartY, line1.EndY);
            var line1EndY = Math.Max(line1.StartY, line1.EndY);
            var line2StartX = Math.Min(line2.StartX, line2.EndX);
            var line2EndX = Math.Max(line2.StartX, line2.EndX);
            var line2StartY = Math.Min(line2.StartY, line2.EndY);
            var line2EndY = Math.Max(line2.StartY, line2.EndY);
            
            // No crossing
            if (line1StartX < line2StartX && line1EndX < line2StartX)
                return null;
            if (line1StartX > line2EndX && line1EndX > line2EndX)
                return null;
            if (line1StartY < line2StartY && line1EndY < line2StartY)
                return null;
            if (line1StartY > line2EndY && line1EndY > line2EndY)
                return null;

            var intersection = line1StartX == line1EndX
                ? new Point(line1StartX, line2StartY)
                : new Point(line2StartX, line1StartY);

            return intersection;
        }

        private static ImmutableList<Line> CalculateWirePositions(string wireInput)
        {
            var instructions = wireInput.Split(",")
                .Select(inp => new Instruction (inp[..1], int.Parse(inp[1..]) ));

            var allPoints = instructions.Aggregate(ImmutableList<Line>.Empty.Add(new Line(0, 0, 0, 0)), DrawWire);
            return allPoints.Skip(1).ToImmutableList();
        }

        private static ImmutableList<Line> DrawWire(ImmutableList<Line> currentPath, Instruction nextInstruction)
        {
            var (direction, distance) = nextInstruction;
            var delta = direction switch
            {
                "U" => new { deltaX = 0, deltaY = -distance},
                "D" => new { deltaX = 0, deltaY = distance},
                "R" => new { deltaX = distance, deltaY = 0},
                "L" => new { deltaX = -distance, deltaY = 0},
                _ => throw new ApplicationException($"Unexpected Direction {direction}"),
            };
            
            var lastLine = currentPath.Last();
            return currentPath.Add(new Line(lastLine.EndX, lastLine.EndY, lastLine.EndX + delta.deltaX,
                lastLine.EndY + delta.deltaY));
        }
    }
}