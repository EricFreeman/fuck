using System.IO;
using System.Linq;

namespace fuck
{
    public class FileReader
    {
        FileLocator Locator = new FileLocator();
        public string GetPreviousCommand()
        {
            var lines = File.ReadAllLines(Locator.BashHistoryPath());
            return lines.Last();
        }

        
    }
}