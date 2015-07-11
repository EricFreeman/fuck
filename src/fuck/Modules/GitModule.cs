using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            var inputtedCommandAndArguments = input.Split(' ').ToList();
            inputtedCommandAndArguments.RemoveAt(0);

            var commandToFix = inputtedCommandAndArguments[0];
            
            inputtedCommandAndArguments.RemoveAt(0);
            var arguments = inputtedCommandAndArguments.Count > 0 ? inputtedCommandAndArguments : new List<string>();

            var dictionaryLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
            var commands = File.ReadAllLines(dictionaryLocation.Replace("fuck.exe", "git dictionary.txt"));

            var command = commands.Where(x => Levenshtein.Calculate(x, commandToFix) <= Tolerance);

            var possibleCorrections = command.OrderBy(x => Levenshtein.Calculate(x, commandToFix)).Select(x => "git " + x + " " + string.Join(" ", arguments).Trim()).ToList();

            return possibleCorrections;
        }
    }
}