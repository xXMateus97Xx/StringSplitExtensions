namespace StringSplitIndex
{
    public static partial class StringSplitExtensions
    {
        public static StringSplitEnumerable SplitFast(this string str, ReadOnlySpan<char> separator, StringSplitOptions options = StringSplitOptions.None)
        {
            return SplitFast(str.AsSpan(), separator, options);
        }

        public static StringSplitEnumerable SplitFast(this ReadOnlySpan<char> str, ReadOnlySpan<char> separator, StringSplitOptions options = StringSplitOptions.None)
        {
            CheckStringSplitOptions(options);
            return new StringSplitEnumerable(str, separator, options);
        }

        public ref struct StringSplitEnumerable
        {
            private ReadOnlySpan<char> _str;
            private readonly ReadOnlySpan<char> _separator;
            private readonly StringSplitOptions _options;
            private bool _returnLastEmpty;

            public StringSplitEnumerable(ReadOnlySpan<char> str, ReadOnlySpan<char> separator, StringSplitOptions options)
            {
                _str = str;
                _separator = separator;
                _options = options;
                Current = ReadOnlySpan<char>.Empty;
                _returnLastEmpty = (options & StringSplitOptions.RemoveEmptyEntries) == 0 && str.EndsWith(separator);
            }

            public StringSplitEnumerable GetEnumerator() => this;

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

                if (_separator.Length == 0)
                {
                    _str = ReadOnlySpan<char>.Empty;
                    current = span;
                    goto applyOptions;
                }

                var index = span.IndexOf(_separator);
                if (index == -1)
                {
                    _str = ReadOnlySpan<char>.Empty;
                    current = span;
                    goto applyOptions;
                }

                _str = span.Slice(index + _separator.Length);
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
