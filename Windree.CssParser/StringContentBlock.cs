using System.Diagnostics.CodeAnalysis;

namespace Windree.CssParser;

public class StringContentBlock
{
    private const string SingleQuote = "'";
    private const string DoubleQuote = "\"";
    private const string BackQuote = "`";
    public static bool Parse(string s, int offset, out int newOffset, [NotNullWhen(true)] out ContentBlock? contentBlock)
    {
        foreach (var quote in new[] { SingleQuote, DoubleQuote, BackQuote })
        {
            if (!Utils.TryFindSolidBlock(s, offset, quote, quote, out var newQuoteOffset)) continue;
            newOffset = newQuoteOffset;
            contentBlock = new ContentBlock
            {
                Type = CodeBlockType.String,
                StartOffset = offset,
                EndOffset = newOffset,
                Blocks = Array.Empty<ContentBlock>()
            };
            return true;
        }

        newOffset = offset;
        contentBlock = null;
        return false;
    }
}