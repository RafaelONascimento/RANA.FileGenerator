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
        private int _precision;
        private bool _useDecimalChar;
        private bool _useUnitThousands;

        public DecimalValue(int index, int initialPosition = -1, int finalPosition = -1, PaddingOrientation paddingOrientation = PaddingOrientation.Left, char paddingChar = ' ', int precision = 2,bool useDecimalChar = true, bool useUnitThousands = true) : base(index,initialPosition, finalPosition, paddingOrientation, paddingChar)
        {
            _precision = precision;
            _useDecimalChar = useDecimalChar;
            _useUnitThousands = useUnitThousands;
        }

        public DecimalValue(int index, int initialPosition = -1, int finalPosition = -1, bool useDecimalChar = true, int precision = 2) : base(index, initialPosition, finalPosition)
        {
            _precision = precision;
            _useDecimalChar = useDecimalChar;
        }

        #region Private Methods
        private string FormatValue(decimal value)
        {

            string formatedValue = ((decimal)(value)).ToString($"N{_precision}");

            formatedValue = _useUnitThousands ? formatedValue : formatedValue.Replace(".", "");

            formatedValue = _useDecimalChar ? formatedValue : formatedValue.Replace(".","").Replace(",","");

            return StringUtil.SubstringNumericValue(_initialPosition, _finalPosition, formatedValue);
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