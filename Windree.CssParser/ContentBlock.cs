using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windree.CssParser.Entities;

namespace Windree.CssParser
{
    public class ContentBlock
    {
        public int StartOffset { get; init; }
        public int EndOffset { get; init; }
        public CodeBlockType Type { get; set; }
    }
}

