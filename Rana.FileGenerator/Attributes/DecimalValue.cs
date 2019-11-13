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

        public DecimalValue(int index, int initialPosition = -1, int finalPosition = -1, PaddingOrientation paddingOrientation = PaddingOrientation.Left, char paddingChar = ' ', int precision = 2,bool useDecimalChar = true) : base(index,initialPosition, finalPosition, paddingOrientation, paddingChar)
        {
            _precision = precision;
            _useDecimalChar = useDecimalChar;
        }

        #region Private Methods
        private string FormatValue(decimal value)
        {
            string formatedValue = ((decimal)(value)).ToString($"N{_precision}");

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