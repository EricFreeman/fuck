namespace fuck.Modules
{
    public interface IModule
    {
        bool IsMatch(string input);
        string GetCorrectInput(string input);
    }
}