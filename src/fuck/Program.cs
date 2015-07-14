namespace fuck
{
    class Program
    {
        public static void Main(string[] args)
        {
            var commandParser = new FileReader();
            var input = commandParser.GetPreviousCommand();

            var moduleRunner = new ModuleRunner();
            moduleRunner.Execute(input);
        }
    }
}