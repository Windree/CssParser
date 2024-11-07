namespace Windree.CssParser;

public class ContentBlock
{
    public required CodeBlockType Type { get; init; }
    public required ContentBlock[] Blocks { get; init; }
    public required int StartOffset { get; init; }
    public required int EndOffset { get; init; }

}