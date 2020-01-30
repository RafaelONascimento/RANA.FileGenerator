using Rana.FileGenerator.Enums;
using Rana.FileGenerator.Util;

namespace Rana.FileGenerator.Attributes
{
    public class BooleanValue : Value
    {
        public BooleanValue(int index, int initialPosition = -1, int finalPosition = -1, PaddingOrientation paddingOrientation = PaddingOrientation.Left, char paddingChar = ' ') : base(index, initialPosition, finalPosition, paddingOrientation, paddingChar)
        {
        }

        public override string Generate(dynamic value)
        {
            return base.Generate(StringUtil.SubstringBooleanValue(_initialPosition, _finalPosition, ((bool)value).ToString()));
        }
    }
}