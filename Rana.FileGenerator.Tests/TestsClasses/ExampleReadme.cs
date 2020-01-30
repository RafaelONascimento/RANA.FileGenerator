using Rana.FileGenerator.Attributes;
using Rana.FileGenerator.Enums;
using System;


namespace Rana.FileGenerator.Tests.TestsClasses
{
    public class ExampleReadme : LineContent
    {
        [StringValue(Index = 0)]
        public string Description { get; set; }

        [NumericValue(Index = 1,Size = 5, PaddingOrientation = PaddingOrientation.Left, PaddingChar = '0')]
        public int Id { get; set; }

        [StringValue(Index = 2, Size = 9, PaddingOrientation = PaddingOrientation.Right, PaddingChar = '_')]
        public string Name { get; set; } 

        [DecimalValue(Index = 3,Precision = 2,UseDecimalChar = true, Size = 8, PaddingChar = '0')]
        public decimal Price { get; set; }

        [DateTimeValue(Index = 3,DateFormat = "MM/dd/yyyy")]
        public DateTime DateAdded { get; set; }
    }
}
