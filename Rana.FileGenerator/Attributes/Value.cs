using Rana.FileGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rana.FileGenerator.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public abstract class Value : Attribute
    {
        protected int _initialPosition;
        protected int _finalPosition;
        private PaddingOrientation _paddingOrientation;
        private char _paddingChar;
        private readonly bool _ignorePadding = false;
        public int Index { get; set; }

        public Value(int index, int initialPosition = -1, int finalPosition = -1)
        {
            _initialPosition = initialPosition;
            _finalPosition = finalPosition;
            Index = index;
            _ignorePadding = true;
        }

        public Value(int index, int initialPosition = -1, int finalPosition = -1, PaddingOrientation paddingOrientation = PaddingOrientation.Left, char paddingChar=' ')
        {
            _initialPosition = initialPosition;
            _finalPosition = finalPosition;
            _paddingOrientation = paddingOrientation;
            _paddingChar = paddingChar;
            Index = index;
        }

        private string PadText(string text)
        {
            int size = _finalPosition - _initialPosition;

            if (_ignorePadding)
            {
                return text.Length > size ?  text.Substring(0, size) : text; 
            }            

            return (_paddingOrientation == PaddingOrientation.Left) ? text.PadLeft(size, _paddingChar) : text.PadRight(size, _paddingChar);
        }

        public virtual string Generate(dynamic value)
        {
            return PadText((value as string));
        }
    }
}
