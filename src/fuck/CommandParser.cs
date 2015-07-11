using System;
using System.IO;
using System.Linq;

namespace fuck
{
    public class CommandParser
    {
        public string GetPreviousCommand()
        {
            var historyLogPath = Environment.GetEnvironmentVariable("home") + @"\.bash_history";
            var lines = File.ReadAllLines(historyLogPath);
            return lines.Last();
        }
    }
}