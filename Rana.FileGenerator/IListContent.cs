using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rana.FileGenerator
{
   public interface IListContent<T> : IEnumerable<T> where T : IContent
    {
        string Generate(string label = "", string separator = null, bool? breakLine = null, bool? separatorAtBegining = null, bool? separatorAtEnd = null);
    }
}
