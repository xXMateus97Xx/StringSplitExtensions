# StringSplitExtensions

Extensions methods that allow to split a string without any allocation.

Inspired by @meziantou [blog post](https://www.meziantou.net/split-a-string-into-lines-without-allocation.htm)

# How to Use

Split by char

```cs
string toSplit = GetString();
char splitIn = GetSplitChar();

foreach (ReadOnlySpan<char> splitted in toSplit.SplitFast(splitIn, StringSplitOptions.RemoveEmptyEntries))
{
    // Use string
}

```

Split in String

```cs
string toSplit = GetString();
string splitIn = GetSplitString();

foreach (ReadOnlySpan<char> splitted in toSplit.SplitFast(splitIn, StringSplitOptions.None))
{
    // Use string
}
```

Split in Any Char

```cs
string toSplit = GetString();
string splitIn = GetSplitAnyString();

foreach (ReadOnlySpan<char> splitted in toSplit.SplitAnyFast(splitIn, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
{
    // Use string
}
```

Split in Any Char With SearchValues<char>

```cs
string toSplit = GetString();
SearchValues<char> splitIn = SearchValues.Create(new[] { ',', ';' });

foreach (ReadOnlySpan<char> splitted in toSplit.SplitAnyFast(splitIn, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
{
    // Use string
}
```