using Rana.FileGenerator.Attributes;
using Rana.FileGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rana.FileGenerator
{
    public class LineContent : IContent
    {
        public string Separator;
        public bool SeparatorAtBegining;
        public bool SeparatorAtEnd;

        public LineContent(string separator = "",bool separatorAtBegining = false, bool separatorAtEnd = false)
        {
            Separator = separator;
            SeparatorAtBegining = separatorAtBegining;
            SeparatorAtEnd = separatorAtEnd;
        }

        public virtual string Generate(string label = "", string separator = null, bool? separatorAtBegining = null, bool? separatorAtEnd = null)
        {
            List<string> content = new List<string>();
            string contentSeparator = separator ?? Separator;
            string contentLabel = (label.Length > 0) ? contentSeparator + label + contentSeparator :separator;

            foreach (FieldInfo field in this.GetType().GetFields().Where(x => x.GetCustomAttributes(typeof(Value), true).Any())
                                                                  .OrderBy(x => (x.GetCustomAttributes(typeof(Value)).First() as Value).Index))
            {
                content.Add(Separator + field.GetCustomAttribute<Value>().Generate(field.GetValue(this)));
            }

            return string.Join(contentSeparator, content) + ((separatorAtEnd ?? SeparatorAtEnd) ? contentSeparator : "") ;
        }
    }
}
