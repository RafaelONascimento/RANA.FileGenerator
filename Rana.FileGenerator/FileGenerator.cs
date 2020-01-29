using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rana.FileGenerator
{
    public class FileGenerator : IGenerator
    {
        protected string _separator;
        protected bool _breakLine;
        protected bool _separatorAtBegining;
        protected bool _separatorAtEnd;

        public FileGenerator(string separator = null, bool? breakLine = null, bool? separatorAtBegining = null, bool? separatorAtEnd = null)
        {
            _separator = separator;
            _breakLine = breakLine ?? false;
            _separatorAtBegining = separatorAtBegining ?? false;
            _separatorAtEnd = separatorAtEnd ?? false;
        }

        public string Generate()
        {
            StringBuilder content = new StringBuilder();
            List<dynamic> fields = new List<dynamic>();

            fields.AddRange(this.GetType().GetProperties().OfType<IContent>());
            fields.AddRange(this.GetType().GetProperties().OfType<IGenerator>());

            foreach (dynamic field in fields)
            {
                if (field is IContent)
                    content.Append(field.Generate(_separator, _separatorAtBegining, _separatorAtEnd) + ((_breakLine) ? @"\n" : ""));
                else
                    content.Append(field.Generate(_separator, _breakLine, _separatorAtBegining, _separatorAtEnd));
            }

            return content.ToString();
        }
    }
}
