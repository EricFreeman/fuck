﻿using System;
using System.IO;
using System.Linq;

namespace fuck
{
    public class FileReader
    {
        public string GetPreviousCommand()
        {
            var historyLogPath = Environment.ExpandEnvironmentVariables("%SystemDrive%\\Users\\"+Environment.UserName) + "\\.bash_history";
            var lines = File.ReadAllLines(historyLogPath);
            return lines.Last();
        }
    }
}