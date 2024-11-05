namespace Windree.CssParser.Entities;

/// <summary>
/// A modificator like hover or before or not()
/// </summary>
public class CssModificator
{
    /// <summary>
    /// A modificator name like hover or before or not
    /// </summary>
    public  required string Name { get; init; }
    public ModificatorArgument? Arguments { get; init; }
}