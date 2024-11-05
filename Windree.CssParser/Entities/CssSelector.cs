namespace Windree.CssParser.Entities;

/// <summary>
/// Selector path like a span, .link.row
/// </summary>
public class CssSelector
{
    /// <summary>
    /// Part of selector separated by comma
    /// </summary>
    public required CssPath[] CssPaths { get; init; }
    public required string Value { get; init; }
}