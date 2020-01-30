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
        private string _dateFormat;

        public DateTimeValue(int index, int initialPosition = -1, int finalPosition = -1, PaddingOrientation paddingOrientation = PaddingOrientation.Left, string dateFormat = "dd/MM/yyyy") : base(index,initialPosition, finalPosition, paddingOrientation)
        {
            _dateFormat = dateFormat;
        }

        public override string Generate(dynamic value)
        {
            return base.Generate(StringUtil.SubstringValue(_initialPosition,_finalPosition,((DateTime)value).ToString(_dateFormat)));
        }

    }
}
