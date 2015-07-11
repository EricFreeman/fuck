using System.Collections.Generic;

namespace fuck.Modules
{
    public class DefaultModule : IModule
    {
        public bool IsMatch(string input)
        {
            return true;
        }

        public List<string> GetCorrectInput(string input)
        {
            return new List<string>();
        }
    }
}