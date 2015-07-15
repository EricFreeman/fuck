namespace fuck.Core
{
    public static class StringExtensions
    {
        public static string IfEmpty(this string source, string destination)
        {
            return source.IsNotEmpty() ? source : destination;
        }

        public static bool IsEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        public static bool IsNotEmpty(this string source)
        {
            return !string.IsNullOrEmpty(source);
        }
    }
}
