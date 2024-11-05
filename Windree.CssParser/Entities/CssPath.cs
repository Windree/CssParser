namespace Windree.CssParser.Entities;

/// <summary>
/// Complex selector expression like a[alt] or .row > a or div + link
/// </summary>
public class CssPath
{
    /// <summary>
    /// parts of css selector and preceding operator like " ".class or > a or + link
    /// </summary>
    public required CssItem[] Item { get; init; }
}