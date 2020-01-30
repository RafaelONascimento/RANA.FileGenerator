using Rana.FileGenerator.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rana.FileGenerator.Tests.TestsClasses
{
    public class DecimalValueWith3PrecisionDigits : LineContent
    {
        [DecimalValue(0,0,6,Enums.PaddingOrientation.Left,'0',3,true) ]   
        public decimal Value { get; set; }
    }
}
