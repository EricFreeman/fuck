using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using fuck.Core;
using fuck.Models;

namespace fuck.Modules
{
    public class GitModule : IModule
    {
        private const int Tolerance = 3;

        public bool IsMatch(string input)
        {
            return input.StartsWith("git") || input.StartsWith("got") || input.StartsWith("gut");
        }

        public List<string> GetCorrectInput(string input)
        {
            var commandParser = new CommandParser();
            var command = commandParser.Parse(input);

            var dictionaryLocation = Assembly.GetEntryAssembly().Location;
            var commands = File.ReadAllLines(dictionaryLocation.Replace("fuck.exe", "git dictionary.txt"));

            command.Recommendations = commands
                .Select(x => TranslateToCommandDistance(x, command))
                .Where(x => x.Weight <= Tolerance)
                .OrderBy(x => x.Weight)
                .Select(x => x.Command);

            return command.UpdatedCommand.ToList();
        }

        private CommandDistance TranslateToCommandDistance(string test, Command command)
        {
            var distance = Levenshtein.Calculate(test, command.Action.IfEmpty(command.Program));

            return new CommandDistance
            {
                Command = test,
                Weight = distance
            };
        }
    }
}