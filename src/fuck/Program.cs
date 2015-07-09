using System;
using System.Diagnostics;
using System.IO;

namespace fuck
{
    class Program
    {
        public static void Main(string[] args)
        {
            string historyLogPath = Environment.GetEnvironmentVariable("home") + @"\.bash_history";
            string[] lines = File.ReadAllLines(historyLogPath);
            var lineToFix = lines[lines.Length - 2];

            if (lineToFix.StartsWith("git"))
            {
                var commandToFix = lineToFix.Replace("git ", "").Split(' ')[0];

                var possible = "checkout";
                var distance = Levenshtein(commandToFix, possible);

                if (distance < 3)
                {
                    var newCommand = "git " + possible + " " + lineToFix.Replace("git", "").Replace(commandToFix, "").Trim();

                    Console.WriteLine("Here's what I think you meant: " + newCommand);

                    ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe");
                    startInfo.Arguments = "/C " + newCommand;
                    startInfo.RedirectStandardError = true;
                    startInfo.RedirectStandardOutput = true;
                    startInfo.UseShellExecute = false;
                    startInfo.CreateNoWindow = true;
                    Process p = Process.Start(startInfo);
                    string output = p.StandardOutput.ReadToEnd();
                    string error = p.StandardError.ReadToEnd();
                    p.WaitForExit();
                    Console.WriteLine(output);
                }
            }
        }

        private static int Levenshtein(string a, string b)
        {
            if (string.IsNullOrEmpty(a))
            {
                return !string.IsNullOrEmpty(b) ? b.Length : 0;
            }

            if (string.IsNullOrEmpty(b))
            {
                return !string.IsNullOrEmpty(a) ? a.Length : 0;
            }

            var d = new int[a.Length + 1, b.Length + 1];

            for (var i = 0; i <= d.GetUpperBound(0); i += 1)
            {
                d[i, 0] = i;
            }

            for (var i = 0; i <= d.GetUpperBound(1); i += 1)
            {
                d[0, i] = i;
            }

            for (var i = 1; i <= d.GetUpperBound(0); i += 1)
            {
                for (var j = 1; j <= d.GetUpperBound(1); j += 1)
                {
                    var cost = Convert.ToInt32(a[i - 1] != b[j - 1]);

                    var min1 = d[i - 1, j] + 1;
                    var min2 = d[i, j - 1] + 1;
                    var min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }

            return d[d.GetUpperBound(0), d.GetUpperBound(1)];
        }
    }
}