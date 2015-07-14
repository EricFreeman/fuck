using fuck.Models;
using System;
using System.Linq;

namespace fuck
{
    public class CommandParser
    {
        private const int Tolerance = 3;

        public Command Parse(string input)
        {
            var command = new Command { OriginalCommand = input };

            var commandParts = input.Split(' ').ToList();

            command.Program = commandParts.Count > 0 ? commandParts[0] : string.Empty;
            command.Action = commandParts.Count > 1 ? commandParts[1] : String.Empty;
            command.Arguments = commandParts.Count > 2 ? string.Join(" ", commandParts.GetRange(2, commandParts.Count - 2).ToList()) : string.Empty;

            return command;
        }
    }
}