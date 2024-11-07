using System.Diagnostics.CodeAnalysis;

namespace Windree.CssParser;

public class PropertiesContentBlock
{
    private const string OpenBracket = "{";
    private const string CloseBracket = "}";
    public static bool Parse(string s, int offset, out int endOffset, [NotNullWhen(true)] out ContentBlock? contentBlock)
    {

        var blocks = new List<ContentBlock>();
        if (!(Utils.Follows(s, offset, OpenBracket)))
        {
            endOffset = offset;
            contentBlock = null;
            return false;
        }

        var i = offset + OpenBracket.Length;
        while (!Utils.Follows(s, i, CloseBracket))
        {
            if (i >= s.Length) throw new UnexpectedEndOfContent(i, CloseBracket);
            if (StringContentBlock.Parse(s, i, out var stringEnd, out var stringBlock))
            {
                i = stringEnd;
                blocks.Add(stringBlock);
                continue;
            }
            if (CommentContentBlock.Parse(s, i, out var commentEnd, out var commentBlock))
            {
                i = commentEnd;
                blocks.Add(commentBlock);
                continue;
            }
            i++;
        }

        endOffset = i + 1;
        contentBlock = new ContentBlock
        {
            Type = CodeBlockType.Properties,
            StartOffset = offset,
            EndOffset = endOffset,
            Blocks = blocks.ToArray()
        };
        return true;
    }
}