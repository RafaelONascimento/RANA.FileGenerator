# RANA.FileGenerator
 Rana.FileGenerator is a library to simplify the generation of structured text files. Using an easily approach to make life easier.
 RANA uses customs annotations  to mark how you want to generate each field/property of a class, and its follow the rules in generation.
 
 ## Example
 
 ### Goal
 <code>|Product|00001|Name_____|00015.13|01/29/2020|</Code> 
 
 ### Code Using RANA
 ##### Declaring class/Entity/Model
 ```C#
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
 ```
 #### Calling generation of one line
 ```C#
ExampleReadme testObject = new ExampleReadme
{
   Description = "Product",
   Id = 1,
   Name = "Name",
   Price = 15.13M,
   DateAdded = new DateTime(2020, 01, 29)
};
 
testObject.Generate("Product","|",separatorAtBegining: true,separatorAtEnd: true);
```

#### Calling generation of multiples lines
The example showed how to generate one line, but if you want to generate the how file, there is a list called ListFileContent that do it for you. Following example:

```C#
ListFileContent<ExampleReadme> linesOfTheFile = new ListFileContent<ExampleReadme>();
linesOfTheFile.Generate("Product", "|", separatorAtBegining: true, separatorAtEnd: true);
```

#### Both examples are at the unit tests, #1 First example is called <em>GenerateReadmeExample</em> and the #2 second <em>GenerateListReadmeExample</em>.
