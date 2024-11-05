﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windree.CssParser.Entities;

namespace Windree.CssParser
{
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

        public CssEntity[] Parse()
        {
            var cssEntity = new List<CssEntity>();
            for (var i = 0; i < content.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(content[i].ToString())) continue;
                if (TryParseComment(i, out var endOffset, out var comment))
                {
                    cssEntity.Add(new CssEntity()
                    {
                        Type = CssRecordType.Comment,
                        Comment = comment
                    });
                    i = endOffset;
                }
            }
            return cssEntity.ToArray();
        }

        private bool TryParseComment(int offset, out int endOffset, [NotNullWhen(true)] out string? comment)
        {
            const string openWith = "/*";
            const string closeWith = "*/";
            if (offset >= content.Length - openWith.Length || content.Substring(offset, openWith.Length) != openWith)
            {
                endOffset = offset;
                comment = null;
                return false;
            }
            var commentStartOffset = offset + openWith.Length;
            var commentEndOffset = content.IndexOf(closeWith, offset + openWith.Length, StringComparison.Ordinal);
            if (commentEndOffset == -1)
            {
                endOffset = content.Length - 1;
                comment = content.Substring(commentStartOffset, content.Length - commentStartOffset);
                return true;
            }
            endOffset = commentEndOffset + closeWith.Length;
            comment = content.Substring(commentStartOffset, commentEndOffset - commentStartOffset);
            return true;
        }

        private void TryParseSelector(long offset)
        {
            if (TryParseComment(0, out var endOffset, out var comment))
            {
                var r1 = endOffset;
                var r2 = comment;
            }
            else
            {
                var r1 = endOffset;
                var r2 = comment;
            }
        }


    }
}
