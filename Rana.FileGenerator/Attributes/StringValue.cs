using Rana.FileGenerator.Enums;
using Rana.FileGenerator.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rana.FileGenerator.Attributes
{
    public class StringValue : Value
    {
        public StringValue(int index, int initialPosition = -1, int finalPosition = -1, PaddingOrientation paddingOrientation = PaddingOrientation.Left, char paddingChar = ' ') : base(index,initialPosition, finalPosition, paddingOrientation, paddingChar)
        {
        }

        public override string Generate(dynamic value)
        {
            return base.Generate(StringUtil.SubstringStringValue(_initialPosition,_finalPosition,value as string));
        }
    }
}