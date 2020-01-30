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
        public int InitialPosition = -1;
        public int FinalPosition = -1;
        public int Size = -1;
        public PaddingOrientation PaddingOrientation;
        public char PaddingChar;
        private readonly bool _ignorePadding = false;
        public int Index { get; set; }

        public Value(int index = 0, int initialPosition = -1, int finalPosition = -1)
        {
            InitialPosition = initialPosition;
            FinalPosition = finalPosition;
            Index = index;
            _ignorePadding = true;
        }

        public Value(int index = 0, int initialPosition = -1, int finalPosition = -1, PaddingOrientation paddingOrientation = PaddingOrientation.Left, char paddingChar=' ')
        {
            InitialPosition = initialPosition;
            FinalPosition = finalPosition;
            PaddingOrientation = paddingOrientation;
            PaddingChar = paddingChar;
            Index = index;
        }

        private string PadText(string text)
        {
            int size =(Size >=0) ? Size :  FinalPosition - InitialPosition;

            if (_ignorePadding)
            {
                return text.Length > size ?  text.Substring(0, size) : text; 
            }            

            return (PaddingOrientation == PaddingOrientation.Left) ? text.PadLeft(size, PaddingChar) : text.PadRight(size, PaddingChar);
        }

        public virtual string Generate(dynamic value)
        {
            return PadText((value as string));
        }
    }
}
