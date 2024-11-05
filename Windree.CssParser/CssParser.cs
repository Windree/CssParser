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
                if (TryParseComment(i, out var endOffset, out var comment))
                {
                    cssEntity.Add(new CssEntity()
                    {
                        Type = CssRecordType.Comment,
                        Comment = comment
                    });
                }

            }
            return cssEntity.ToArray();
        }

        private bool TryParseComment(int offset, [NotNullWhen(true)] out int? endOffset, [NotNullWhen(true)] out string? comment)
        {
            const string openWith = "/*";
            const string closeWith = "*/";
            if (offset >= content.Length - openWith.Length || content.Substring(offset, 2) != openWith)
            {
                endOffset = null;
                comment = null;
                return false;
            }
            var closeOffset = content.IndexOf(closeWith, StringComparison.Ordinal);
            if (closeOffset == -1)
            {
                endOffset = content.Length - 1;
                comment = null;
                return false;
            }

            var commentStartOffset = offset + openWith.Length;
            endOffset = closeOffset + closeWith.Length;
            comment = content.Substring(commentStartOffset, closeOffset - commentStartOffset);
            return true;
        }

        private void TryParseSelector(long offset)
        {

        }
    }
}
