using Rana.FileGenerator.Attributes;
using Rana.FileGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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
            string contentSeparator = separator ?? string.Empty;
            string contentLabel = (label.Length > 0) ? contentSeparator + label + contentSeparator :separator;

            foreach (PropertyInfo field in this.GetType().GetProperties().Where(x => x.GetCustomAttributes(typeof(Value), true).Any())
                                                                  .OrderBy(x => (x.GetCustomAttributes(typeof(Value), true).First() as Value).Index))
            {

                content.Add(Separator + (field.GetCustomAttributes(typeof(Value), true).First() as Value).Generate(field.GetValue(this, null)));
            }

            return ((separatorAtBegining ?? false) ? contentSeparator : "") + string.Join(contentSeparator, content) + ((separatorAtEnd ?? false) ? contentSeparator : "") ;
        }
    }
}
