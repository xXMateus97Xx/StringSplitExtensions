namespace StringSplitIndex
{
    public static partial class StringSplitExtensions
    {
        private static void CheckStringSplitOptions(StringSplitOptions options)
        {
            const StringSplitOptions AllValidFlags = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;

            if ((options & ~AllValidFlags) != 0)
            {
                throw new ArgumentException("Value of flags is invalid.", nameof(options));
            }
        }
    }
}
