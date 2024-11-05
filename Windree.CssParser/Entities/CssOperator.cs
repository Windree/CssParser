namespace Windree.CssParser.Entities;

public enum CssOperator
{
    /// <summary>
    /// li a - DOM descendant combinator. All a tags that are a child of li tags
    /// </summary>
    Descendant,
    /// <summary>
    /// div.row * - All selects all elements that are descendant (or child) of the elements with div tag and ‘row’ class
    /// </summary>
    All,
    /// <summary>
    /// li > a - Difference combinator. Select direct descendants, instead of all descendants like the descendant selectors
    /// </summary>
    Difference,
    /// <summary>
    /// li + a - The adjacent combinator. It selects the element that is immediately preceded by the former element. In this case, only the first a after each li.
    /// </summary>
    Adjacent,
    /// <summary>
    /// li ~ a - The sibling combinator. Selects a element following a li element.
    /// </summary>
    Sibling,
}