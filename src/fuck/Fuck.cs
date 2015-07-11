using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using fuck.Modules;

namespace fuck
{
    public class Fuck
    {
        private readonly List<IModule> _modules;

        public Fuck()
        {
            _modules = new List<IModule>
            {
                new GitModule(),
                new DefaultModule()
            };
        }

        public void Execute()
        {
            var input = GetIncorrectInput();

            Console.WriteLine("Input: " + input);

            var output = _modules.First(x => x.IsMatch(input)).GetCorrectInput(input);

            if (output != string.Empty)
            {
                Console.WriteLine("Corrected: " + output);
                RunCommand(output);
            }
            else
            {
                Console.WriteLine("Even I don't know what the hell you were trying to do.");
            }
        }

        private static void RunCommand(string output)
        {
            var startInfo = new ProcessStartInfo("cmd.exe")
            {
                Arguments = "/C " + output,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var p = Process.Start(startInfo);
            var processOutput = p.StandardOutput.ReadToEnd();
            var processError = p.StandardError.ReadToEnd();
            p.WaitForExit();

            Console.WriteLine(processOutput);
            Console.WriteLine(processError);
        }

        public string GetIncorrectInput()
        {
            var historyLogPath = Environment.GetEnvironmentVariable("home") + @"\.bash_history";
            var lines = File.ReadAllLines(historyLogPath);
            return lines.Last();
        }
    }
}