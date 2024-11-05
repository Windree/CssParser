namespace Windree.CssParser.Entities;

public class ModificatorArgument
{
    public ModificatorArgumentType Type { get; init; }
    public string? Simple { get; init; }
    public CssItem? Complex { get; init; }
}