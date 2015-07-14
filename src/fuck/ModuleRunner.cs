using fuck.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace fuck
{
    public class ModuleRunner
    {
        private readonly List<IModule> _modules;

        public ModuleRunner()
        {
            _modules = new List<IModule>
            {
                new GitModule(),
                new DefaultModule()
            };
        }

        public void Execute(string input)
        {
            Console.WriteLine("Input: " + input);

            var output = _modules.First(x => x.IsMatch(input)).GetCorrectInput(input);

            if (output.Any())
            {
                var selection = output.Count > 1 ? GetSelectedCommand(output) : 0;
                Console.WriteLine("Corrected: " + output[selection]);
                RunCommand(output[selection]);
            }
            else
            {
                Console.WriteLine("Even I don't know what the hell you were trying to do.");
            }
        }

        private int GetSelectedCommand(List<string> output)
        {
            for (var i = 0; i < output.Count; i++)
            {
                Console.WriteLine(i + ") " + output[i]);
            }

            while (true)
            {
                Console.Write("> ");
                var selectionString = Console.ReadLine();

                int selection;

                if (int.TryParse(selectionString, out selection) && output.Count > selection)
                {
                    if (selection < output.Count)
                    {
                        return selection;
                    }
                }
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
    }
}