using Rana.FileGenerator.Enums;
using Rana.FileGenerator.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rana.FileGenerator.Attributes
{
    public class DateTimeValue : Value
    {
        public string DateFormat;

        public DateTimeValue(int index = 0, int initialPosition = -1, int finalPosition = -1, PaddingOrientation paddingOrientation = PaddingOrientation.Left, string dateFormat = "dd/MM/yyyy") : base(index,initialPosition, finalPosition, paddingOrientation)
        {
            DateFormat = dateFormat;
        }

        public override string Generate(dynamic value)
        {
            return base.Generate(StringUtil.SubstringValue(InitialPosition,FinalPosition,((DateTime)value).ToString(DateFormat)));
        }

    }
}
