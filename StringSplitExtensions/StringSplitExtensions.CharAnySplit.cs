namespace StringSplitIndex
{
    public static partial class StringSplitExtensions
    {
        public static CharAnySplitEnumerable SplitAnyFast(this string str, ReadOnlySpan<char> separators, StringSplitOptions options = StringSplitOptions.None)
        {
            return SplitAnyFast(str.AsSpan(), separators, options);
        }

        public static CharAnySplitEnumerable SplitAnyFast(this ReadOnlySpan<char> str, ReadOnlySpan<char> separators, StringSplitOptions options = StringSplitOptions.None)
        {
            CheckStringSplitOptions(options);
            return new CharAnySplitEnumerable(str, separators, options);
        }

        public ref struct CharAnySplitEnumerable
        {
            private ReadOnlySpan<char> _str;
            private readonly ReadOnlySpan<char> _separators;
            private readonly StringSplitOptions _options;
            private bool _returnLastEmpty;

            public CharAnySplitEnumerable(ReadOnlySpan<char> str, ReadOnlySpan<char> separators, StringSplitOptions options)
            {
                _str = str;
                _separators = separators;
                _options = options;
                Current = ReadOnlySpan<char>.Empty;
                _returnLastEmpty = (options & StringSplitOptions.RemoveEmptyEntries) == 0 && separators.Contains(str[^1]);
            }

            public CharAnySplitEnumerable GetEnumerator() => this;

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

                if (_separators.Length == 0)
                {
                    _str = ReadOnlySpan<char>.Empty;
                    current = span;
                    goto applyOptions;
                }

                var index = span.IndexOfAny(_separators);
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
