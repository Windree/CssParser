namespace Windree.CssParser;

internal static class Utils
{
    public static bool TryFindSolidBlock(string s, int offset, string openWith, string closeWith, out int lastOffset)
    {
        if (offset >= s.Length - openWith.Length || s.Substring(offset, openWith.Length) != openWith)
        {
            lastOffset = offset;
            return false;
        }
        var commentEndOffset = s.IndexOf(closeWith, offset + openWith.Length, StringComparison.Ordinal);
        if (commentEndOffset == -1) throw new UnexpectedEndOfContent(s.Length - 1, closeWith);
        lastOffset = commentEndOffset + closeWith.Length;
        return true;
    }

    public static bool Follows(string s, int offset, string subject)
    {
        return offset <= s.Length - subject.Length && s.Substring(offset, subject.Length) == subject;
    }
}