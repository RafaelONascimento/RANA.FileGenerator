using Rana.FileGenerator.Tests.TestsClasses;
using System;
using System.Text;
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

            Assert.Equal((92.752).ToString("N3"), testObject.Generate());
        }

        [Fact]
        public void GenerateReadmeExample()
        {
            ExampleReadme testObject = new ExampleReadme
            {
                Description = "Product",
                Id = 1,
                Name = "Name",
                Price = 15.13M,
                DateAdded = new DateTime(2020, 01, 29)
            };

            ListFileContent<ExampleReadme> linesOfTheFIle = new ListFileContent<ExampleReadme>();
            linesOfTheFIle.Generate("Product", "|", separatorAtBegining: true, separatorAtEnd: true);

            Assert.Equal($"|Product|00001|Name_____|000{(15.13).ToString("N2")}|01/29/2020|", testObject.Generate("Product","|",separatorAtBegining: true,separatorAtEnd: true));
        }
        [Fact]
        public void GenerateListReadmeExample()
        {
            ListFileContent<ExampleReadme> linesOfTheFile = new ListFileContent<ExampleReadme>();

            linesOfTheFile.Add(new ExampleReadme
            {
                Description = "Product",
                Id = 1,
                Name = "Name",
                Price = 15.13M,
                DateAdded = new DateTime(2020, 01, 29)
            });

            linesOfTheFile.Add(new ExampleReadme
            {
                Description = "Product",
                Id = 1,
                Name = "Name",
                Price = 20.95M,
                DateAdded = new DateTime(2020, 01, 29)
            });

            StringBuilder correctAnswer = new StringBuilder();
            correctAnswer.AppendLine($"|Product|00001|Name_____|000{(15.13).ToString("N2")}|01/29/2020|");
            correctAnswer.AppendLine($"|Product|00001|Name_____|000{(20.95).ToString("N2")}|01/29/2020|");

            Assert.Equal(correctAnswer.ToString(), linesOfTheFile.Generate("Product", "|", separatorAtBegining: true, separatorAtEnd: true));
        }
    }
}
