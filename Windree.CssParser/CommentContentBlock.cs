using System.Diagnostics.CodeAnalysis;

namespace Windree.CssParser;

public class CommentContentBlock
{
    public static bool Parse(string s, int offset, out int newOffset, [NotNullWhen(true)] out ContentBlock? contentBlock)
    {
        if (!Utils.TryFindSolidBlock(s, offset, "/*", "*/", out var newCommentOffset))
        {
            newOffset = offset;
            contentBlock = null;
            return false;
        }
        newOffset = newCommentOffset;
        contentBlock = new ContentBlock
        {
            Type = CodeBlockType.Comment,
            StartOffset = offset,
            EndOffset = newOffset,
            Blocks = Array.Empty<ContentBlock>()
        };
        return true;
    }
}