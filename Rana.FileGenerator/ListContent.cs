using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rana.FileGenerator
{
    public class ListFileContent<T> : IListContent<T>  where T : IContent
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public string Generate(string label = "", string separator = null, bool? breakLine = null, bool? separatorAtBegining = null, bool? separatorAtEnd = null)
        {
            StringBuilder content = new StringBuilder();

            this.ToList().ForEach(x =>  content.Append(x.Generate(label, separator,separatorAtBegining,separatorAtEnd)+((breakLine.HasValue && breakLine.Value) ? @"\n" : "")));

            return content.ToString();
        }
    }
}
