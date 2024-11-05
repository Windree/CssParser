using System;
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

        private bool TryParseComment(int offset, out int endOffset, out string comment)
        {
            const string openWith = "/*";
            const string closeWith = "*/";
            if (offset >= content.Length - openWith.Length || content.Substring(offset, 2) != openWith)
            {
                endOffset = offset;
                comment = string.Empty;
                return false;
            }
            var closeOffset = content.IndexOf(closeWith, StringComparison.Ordinal);
            if (closeOffset == -1)
            {
                endOffset = content.Length - 1;
                comment = content.Substring(offset, content.Length - offset);
                return true;
            }

            var commentStartOffset = offset + openWith.Length;
            endOffset = closeOffset + closeWith.Length;
            comment = content.Substring(commentStartOffset, closeOffset - commentStartOffset);
            return true;
        }

        private void TryParseSelector(long offset)
        {
            if (GetValidOrDefaultName(out var s, ""))
            {

            }
        }

        private bool GetValidOrDefaultName([NotNullWhen(true)] out string? validOrDefaultName, string? name)
        {
            if (name is null)
            {
                validOrDefaultName = null;
                return false;
            }
            else
            {
                validOrDefaultName = "defaultName";
                return true;
            }
        }
    }
}
