using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rana.FileGenerator
{
    public interface IContent
    {
        string Generate(string label = "", string separator = null,bool? separatorAtBegining = null, bool? separatorAtEnd = null);
    }
}
