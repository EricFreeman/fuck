namespace fuck.Modules
{
    public class DefaultModule : IModule
    {
        public bool IsMatch(string input)
        {
            return true;
        }

        public string GetCorrectInput(string input)
        {
            return string.Empty;
        }
    }
}