// *********************************************************
// (c) 2021 - 2021 Netzalist GmbH & Co.KG
// *********************************************************

#region Using

using System;
using System.Collections.Immutable;

#endregion

namespace AdventOfCode2019.Day2
{
    public static class Computer
    {
        public static int ExecuteProgram(ImmutableList<int> programCode, int noun, int verb)
        {
            return ExecuteInstruction(programCode.SetItem(1, noun).SetItem(2, verb), 0)[0];
        }

        private static ImmutableList<int> ExecuteInstruction(ImmutableList<int> programCode, int programPointer)
        {
            if (programPointer >= programCode.Count)
                throw new ApplicationException("Reached end of instructions");
            if (programCode[programPointer] == 99)
                return programCode;

            return programCode[programPointer] switch
            {
                1 => ExecuteInstruction(
                    programCode.SetItem(
                        programCode[programPointer + 3],
                        programCode[programCode[programPointer + 1]] + programCode[programCode[programPointer + 2]]
                    ),
                    programPointer + 4
                ),
                2 => ExecuteInstruction(
                    programCode.SetItem(
                        programCode[programPointer + 3],
                        programCode[programCode[programPointer + 1]] * programCode[programCode[programPointer + 2]]
                    ),
                    programPointer + 4
                ),
                _ => throw new ApplicationException($"Unexpected instruction {programCode[programPointer]}"),
            };
        }
    }
}