namespace Windree.CssParser;

public class RootContentBlock(string s)
{
    private readonly List<ContentBlock> blocks = new();

    public ContentBlock[] Parse()
    {

        var i = 0;
        while (i < s.Length)
        {
            if (StringContentBlock.Parse(s, i, out var stringEndOffset, out var stringBlock))
            {
                i = stringEndOffset;
                blocks.Add(stringBlock);
                continue;

            }
            else if (CommentContentBlock.Parse(s, i, out var commentEndOffset, out var commentBlock))
            {
                i = commentEndOffset;
                blocks.Add(commentBlock);
                continue;
            }
            else if (PropertiesContentBlock.Parse(s, i, out var propertiesEndOffset, out var propertiesBlock))
            {
                i = propertiesEndOffset;
                blocks.Add(propertiesBlock);
                continue;
            }
            //else (SelectorContentBlock.Parse(s, 0, out var selectorStart, out var selectorEnd, out var selectorBlock))
            //{

            //}
            i++;
        }
        return blocks.ToArray();
    }
}