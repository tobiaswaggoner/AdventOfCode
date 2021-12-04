// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reactive.Linq;

#endregion

namespace AdventOfCode.Y2021.Day4
{
    public class Day04_1 : IPuzzle
    {
        public void Run()
        {
            var input = new StreamReader(Path.Combine("Y2021", "Day4", "PuzzleInput.txt"));
            var inputValues = input.ReadLine()!.Split(",").Select(int.Parse).ToList();
            
            var initialState = new State(
                input.ReadToEnd()
                    .Split("\r\n\r\n", StringSplitOptions.TrimEntries)
                    .Select(ReadBoard)
                    .Select(InitializeColumns)
                    .ToImmutableList(), -1, -1);

            var endState = inputValues.Aggregate(initialState,
                (currentState, nextNumber) => currentState.Boards.Aggregate(currentState,
                    (state, board) => RemoveNumberFromBoard(state, board, nextNumber)
                )
            );

            Console.WriteLine($"2021 - Day 4/1: {endState.WinScore}");
        }

        private static Board ReadBoard(string boardData)
        {
            return new Board(boardData.Split("\r\n", StringSplitOptions.TrimEntries)
                .Select(row => row
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToImmutableList()
                ).ToImmutableList()
            );
        }

        private static Board InitializeColumns(Board board)
        {
            return board with
            {
                RowsAndColumns = board.RowsAndColumns
                    .AddRange(
                        Enumerable.Range(0, board.RowsAndColumns.Count)
                            .Select(rowIndex => Enumerable.Range(0, board.RowsAndColumns[0].Count)
                                .Select(colIndex => board.RowsAndColumns[colIndex][rowIndex]).ToImmutableList()
                            )
                            .ToImmutableList()
                    )
            };
        }

        private static State RemoveNumberFromBoard(State state, Board board, int nextNumber)
        {
            var alreadyWon = state.winner > -1;
            var newBoard = board with
            {
                RowsAndColumns = board.RowsAndColumns
                    .Select(rowAndColumn => rowAndColumn.Remove(nextNumber))
                    .ToImmutableList()
            };

            var newlyWon = !alreadyWon && newBoard.RowsAndColumns.Any(rowOrColumn => rowOrColumn.Count == 0);
            
            return state with
            {
                Boards = state.Boards.Replace(board, newBoard),
                winner = newlyWon ? state.Boards.IndexOf(board) : state.winner,
                WinScore = newlyWon ? newBoard.RowsAndColumns.SelectMany(rowAndColumn => rowAndColumn).Sum() * nextNumber / 2 : state.WinScore
            };
        }
    }
}