namespace Windree.CssParser;

public class UnexpectedEndOfContent(int offset, string expect) : Exception($"Closing '{expect}' not found at {offset}");