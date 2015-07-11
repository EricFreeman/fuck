namespace fuck
{
    class Program
    {
        public static void Main(string[] args)
        {
            var commandParser = new CommandParser();
            var input = commandParser.GetPreviousCommand();

            var moduleRunner = new ModuleRunner();
            moduleRunner.Execute(input);
        }
    }
}