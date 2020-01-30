using Rana.FileGenerator.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rana.FileGenerator.Tests.TestsClasses
{
    public class StringValueWithPadding : LineContent
    {
        [StringValue(0,0,12,Enums.PaddingOrientation.Left,' ') ]   
        public string Text { get; set; }
    }
}
