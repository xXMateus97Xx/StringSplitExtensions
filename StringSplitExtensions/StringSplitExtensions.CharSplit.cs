namespace StringSplitIndex
{
    public static partial class StringSplitExtensions
    {
        public static CharSplitEnumerable SplitFast(this string str, char separator, StringSplitOptions options = StringSplitOptions.None)
        {
            return SplitFast(str.AsSpan(), separator, options);
        }

        public static CharSplitEnumerable SplitFast(this ReadOnlySpan<char> str, char separator, StringSplitOptions options = StringSplitOptions.None)
        {
            CheckStringSplitOptions(options);
            return new CharSplitEnumerable(str, separator, options);
        }

        public ref struct CharSplitEnumerable
        {
            private ReadOnlySpan<char> _str;
            private readonly char _separator;
            private readonly StringSplitOptions _options;
            private bool _returnLastEmpty;

            public CharSplitEnumerable(ReadOnlySpan<char> str, char separator, StringSplitOptions options)
            {
                _str = str;
                _separator = separator;
                _options = options;
                Current = ReadOnlySpan<char>.Empty;
                _returnLastEmpty = (options & StringSplitOptions.RemoveEmptyEntries) == 0 && str[^1] == separator;
            }

            public CharSplitEnumerable GetEnumerator() => this;

            public bool MoveNext()
            {
                var span = _str;
                if (span.Length == 0)
                {
                    if (_returnLastEmpty)
                    {
                        Current = span;
                        _returnLastEmpty = false;
                        return true;
                    }

                    return false;
                }

                ReadOnlySpan<char> current;

                var index = span.IndexOf(_separator);
                if (index == -1)
                {
                    _str = ReadOnlySpan<char>.Empty;
                    current = span;
                    goto applyOptions;
                }

                _str = span.Slice(index + 1);
                current = span.Slice(0, index);

            applyOptions:
                if ((_options & StringSplitOptions.TrimEntries) != 0)
                    current = current.Trim();

                if ((_options & StringSplitOptions.RemoveEmptyEntries) != 0 && current.Length == 0)
                    return MoveNext();

                Current = current;

                return true;
            }

            public ReadOnlySpan<char> Current { get; private set; }
        }
    }
}
