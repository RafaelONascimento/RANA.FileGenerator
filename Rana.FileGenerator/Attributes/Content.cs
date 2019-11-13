using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rana.FileGenerator.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class Content : Attribute
    {
        public int Index { get; set; } = -1;

        public string Label { get; set; } = null;
    }
}
