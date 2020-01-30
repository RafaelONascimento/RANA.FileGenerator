using Rana.FileGenerator.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rana.FileGenerator.Tests.TestsClasses
{
    public class DateTimeDateFormatMMyyyyDD : LineContent
    {
        [DateTimeValue(0,0,10,Enums.PaddingOrientation.Left,"MM/yyyy/dd") ]   
        public DateTime Date { get; set; }
    }
}
