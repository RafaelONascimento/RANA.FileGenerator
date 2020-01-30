using Rana.FileGenerator.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rana.FileGenerator.Tests.TestsClasses
{
    public class DateTimeDateFormatddMMyyyy : LineContent
    {
        [DateTimeValue(0,0,10,Enums.PaddingOrientation.Left,"dd/MM/yyyy") ]   
        public DateTime Date { get; set; }
    }
}
