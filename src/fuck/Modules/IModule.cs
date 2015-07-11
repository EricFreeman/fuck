using System.Collections.Generic;

namespace fuck.Modules
{
    public interface IModule
    {
        bool IsMatch(string input);
        List<string> GetCorrectInput(string input);
    }
}