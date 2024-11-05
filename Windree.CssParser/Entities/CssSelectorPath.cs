namespace Windree.CssParser.Entities;

/// <summary>
/// Selector path like a span, .link.row
/// </summary>
public class CssSelectorPath
{
    /// <summary>
    /// Part of selector separated by comma
    /// </summary>
    public CssPath[] CssPaths { get; init; } = { };
}