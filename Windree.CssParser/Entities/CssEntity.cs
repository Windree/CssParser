namespace Windree.CssParser.Entities;

/// <summary>
/// A css selector with value or another file entity like a comment
/// </summary>
public class CssEntity
{
    /// <summary>
    /// Type of css entity
    /// </summary>
    public CssRecordType Type { get; init; }
    /// <summary>
    /// Selector path in case an entity is a selector
    /// </summary>
    public CssSelectorPath? SelectorPath { get; init; }
    /// <summary>
    /// </summary>
    /// A comment text
    public string? Comment { get; init; }
}