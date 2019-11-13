using Rana.FileGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rana.FileGenerator.Enums;
using Rana.FileGenerator.Attributes;

namespace WindowsFormsApp1
{
    public class SPED : LineContent
    {
        [NumericValue(0,0,4,PaddingOrientation.Left,'0')]
        public int Codigo;

        [StringValue(1, 5, 7, PaddingOrientation.Left, ' ')]
        public string Nome;

        [DecimalValue(2, 8, 40, PaddingOrientation.Right, '+', 2,false)]
        public decimal Valor;
    }
}
