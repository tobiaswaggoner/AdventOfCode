// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

using System.Collections.Immutable;

namespace AdventOfCode.Y2021.Day4
{
    public record State(ImmutableList<Board> Boards, int winner, int WinScore);
}