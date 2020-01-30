using Rana.FileGenerator.Enums;
using Rana.FileGenerator.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Rana.FileGenerator.Attributes
{
    public class DecimalValue : Value
    {
        public int Precision;
        public bool UseDecimalChar;
        public bool UseUnitThousands;

        public DecimalValue(int index = 0, int initialPosition = -1, int finalPosition = -1, PaddingOrientation paddingOrientation = PaddingOrientation.Left, char paddingChar = ' ', int precision = 2,bool useDecimalChar = true, bool useUnitThousands = true) : base(index,initialPosition, finalPosition, paddingOrientation, paddingChar)
        {
            Precision = precision;
            UseDecimalChar = useDecimalChar;
            UseUnitThousands = useUnitThousands;
        }

        #region Private Methods
        private string FormatValue(decimal value)
        {

            string formatedValue = ((decimal)(value)).ToString($"N{Precision}");

            formatedValue = UseUnitThousands ? formatedValue : formatedValue.Replace(".", "");

            formatedValue = UseDecimalChar ? formatedValue : formatedValue.Replace(".","").Replace(",","");

            return (FinalPosition + InitialPosition + Size) >=0 ?  StringUtil.SubstringNumericValue((Size >= 0) ? Size : FinalPosition - InitialPosition, formatedValue) : formatedValue;
        }
        #endregion

        #region Public Methods
        public override string Generate(dynamic value)
        {
            return base.Generate(FormatValue((decimal)value));
        }
        #endregion
    }
}