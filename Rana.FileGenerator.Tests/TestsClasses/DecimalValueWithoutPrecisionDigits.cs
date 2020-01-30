using Rana.FileGenerator.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rana.FileGenerator.Tests.TestsClasses
{
    public class DecimalValueWithoutPrecisionDigits : LineContent
    {
        [DecimalValue(0,0,5,Enums.PaddingOrientation.Left,'0',0,true) ]   
        public decimal Value { get; set; }
    }
}
