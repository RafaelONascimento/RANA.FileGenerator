using Rana.FileGenerator.Enums;
using Rana.FileGenerator.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rana.FileGenerator.Attributes
{
    public class NumericValue : Value
    {
        public NumericValue(int index = 0, int initialPosition = -1, int finalPosition = -1, PaddingOrientation paddingOrientation = PaddingOrientation.Left, char paddingChar = ' ') : base(index, initialPosition, finalPosition, paddingOrientation, paddingChar)
        {
        }

        public override string Generate(dynamic value)
        {
            return base.Generate(StringUtil.SubstringNumericValue((Size >= 0) ? Size : FinalPosition - InitialPosition, ((int)value).ToString()));
        }
    }
}
