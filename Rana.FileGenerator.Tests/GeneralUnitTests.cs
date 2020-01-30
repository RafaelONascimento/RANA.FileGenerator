using Rana.FileGenerator.Tests.TestsClasses;
using System;
using Xunit;

namespace Rana.FileGenerator.Tests
{
    public class GeneralUnitTests
    {
        [Fact]
        public void GenerateStringValueWithPaddingCharSpace12Positions()
        {
            StringValueWithPadding testObject = new StringValueWithPadding
            {
                Text = "Testing"
            };

            Assert.Equal("     Testing", testObject.Generate());
        }

        [Fact]
        public void GenerateStringValueWithPaddingCharComma10Positions()
        {
            StringValueWithPaddingCharComma testObject = new StringValueWithPaddingCharComma
            {
                Text = "Testing"
            };

            Assert.Equal("Testing,,,", testObject.Generate());
        }

        [Fact]
        public void GenerateDateTimeWithDateFormatMMyyyydd()
        {
            DateTimeDateFormatMMyyyyDD testObject = new DateTimeDateFormatMMyyyyDD
            {
                Date = new DateTime(2019,12,27)
            };

            Assert.Equal("12/2019/27", testObject.Generate());
        }

        [Fact]
        public void GenerateDateTimeWithDateFormatddMMyyyy()
        {
            DateTimeDateFormatddMMyyyy testObject = new DateTimeDateFormatddMMyyyy
            {
                Date = new DateTime(2020, 01, 29)
            };

            Assert.Equal("29/01/2020", testObject.Generate());
        }

        [Fact]
        public void GenerateDecimalValueWithoutPrecisionDigits()
        {
            DecimalValueWithoutPrecisionDigits testObject = new DecimalValueWithoutPrecisionDigits
            {
                Value = 15.12M
            };

            Assert.Equal("00015", testObject.Generate());
        }

        [Fact]
        public void GenerateDecimalValueWith3PrecisionDigits()
        {
            DecimalValueWith3PrecisionDigits testObject = new DecimalValueWith3PrecisionDigits
            {
                Value = 92.75154M
            };

            Assert.Equal("92,752", testObject.Generate());
        }
    }
}
