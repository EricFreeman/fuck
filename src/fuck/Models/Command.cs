using System.Collections.Generic;
using System.Linq;

namespace fuck.Models
{
    public class Command
    {
        public string OriginalCommand { get; set; }
        public IEnumerable<string> UpdatedCommand => Recommendations.Select(x => Program + " " + x + " " + Arguments);

        public string Program { get; set; }
        public string Action { get; set; }
        public string Arguments { get; set; }

        public IEnumerable<string> Recommendations { get; set; } 
    }
}