using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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

            command.Recommendations = commands.Where(x => Levenshtein.Calculate(x, command.Action) <= Tolerance).OrderBy(x => Levenshtein.Calculate(x, command.Action));

            return command.UpdatedCommand.ToList();
        }
    }
}