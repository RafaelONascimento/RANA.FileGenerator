using Rana.FileGenerator.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rana.FileGenerator.Tests.TestsClasses
{
    public class StringValueWithPaddingCharComma : LineContent
    {
        [StringValue(0,0,10,Enums.PaddingOrientation.Right,',') ]   
        public string Text { get; set; }
    }
}
