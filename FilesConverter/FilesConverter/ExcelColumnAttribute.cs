using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesConverter
{
    public class ExcelColumnAttribute : Attribute
    {
        public string Name { get; set; }

    }
}
