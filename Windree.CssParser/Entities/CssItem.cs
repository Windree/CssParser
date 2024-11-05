namespace Windree.CssParser.Entities;

/// <summary>
/// Atom selector with preceding operator
/// </summary>
public class CssItem
{
    /// <summary>
    /// Css Operator like ' ' or > or * or . or + or ~
    /// </summary>
    public CssOperator Operator { get; init; }
    /// <summary>
    /// Selector atom like a or .class or "" for * operator
    /// </summary>
    public required string Name { get; init; }
    /// <summary>
    /// Atom selector modificator like hover or before or not(.other)
    /// </summary>
    public CssModificator? Modificator { get; init; }
}