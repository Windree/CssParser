using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windree.CssParser.Entities;

namespace Windree.CssParser;

public class CssParser
{
    private readonly string content;

    public CssParser(string s)
    {
        if (s.LongCount() > int.MaxValue)
        {
            throw new ArgumentException(nameof(s),
                $"The string is too long. The maximum length is {int.MaxValue}");
        }

        content = s;
    }

    public ContentBlock[] Parse()
    {
        var contentBlocks = new List<ContentBlock>();
        var i = 0;
        var space = new StringBuilder();

        while (i < content.Length)
        {
            if (TryParseSpaceBlock(content, i, out var startSpaceOffset, out var endSpaceOffset))
            {
                contentBlocks.Add(new ContentBlock
                {
                    Type = CodeBlockType.Space,
                    StartOffset = startSpaceOffset,
                    EndOffset = endSpaceOffset
                });
                i = endSpaceOffset;
                continue;
            }

            //if (TryGetSolidBlock(content, i, "/*", "*/", out var startOffset, out var endOffset))
            //{
            //    contentBlocks.Add(new ContentBlock
            //    {
            //        Type = CodeBlockType.Comment,
            //        StartOffset = startOffset,
            //        EndOffset = endOffset
            //    });
            //    i = endOffset;
            //    continue;
            //}
            i++;
        }
        return contentBlocks.ToArray();
    }

    private static bool TryParseSpaceBlock(string s, int offset, out int startOffset, out int endOffset)
    {
        startOffset = endOffset = offset;

        if (offset == s.Length) return false;

        for (var i = offset; i < s.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(s[i].ToString()))
            {
                endOffset = i;
                continue;
            }
            else
            {
                endOffset = i;
                return i != offset;
            }
        }
        endOffset = s.Length;
        return true;
    }

    //private static bool TryGetSolidBlock(string s, int offset, string openWith, string closeWith, out int startOffset, out int lastOffset)
    //{
    //    if (offset >= s.Length - openWith.Length || s.Substring(offset, openWith.Length) != openWith)
    //    {
    //        startOffset = lastOffset = offset;
    //        return false;
    //    }
    //    startOffset = offset + openWith.Length;
    //    var commentEndOffset = s.IndexOf(closeWith, offset + openWith.Length, StringComparison.Ordinal);
    //    if (commentEndOffset == -1)
    //    {
    //        commentEndOffset = s.Length;
    //    }
    //    lastOffset = commentEndOffset;
    //    return true;
    //}

    //private bool TryParseSelector(int offset, [NotNullWhen(true)] out CssEntity? cssEntity)
    //{
    //    const char cssStylesOpen = '{';
    //    const char cssStylesClose = '}';
    //    var selectorStartOffset = offset;
    //    var selectorEndOffset = content.IndexOf(cssStylesOpen, offset);
    //    if (selectorEndOffset == -1)
    //    {
    //        selectorEndOffset = content.Length;
    //    }

    //    var selector = content.Substring(selectorStartOffset, selectorEndOffset - selectorStartOffset).Trim();
    //    GetBlock(selectorEndOffset, out var cssValueOffset, out var value);
    //    cssEntity = null;
    //    return true;
    //}

    //private string GetBlock(int offset, string start, string end, out int lastOffset, out string? blockContent)
    //{
    //    if (offset < content.Length - 1)
    //    {
    //        lastOffset = offset;
    //        value = "";
    //        return;
    //    }

    //    var blockChar = content[..1];

    //}



}
