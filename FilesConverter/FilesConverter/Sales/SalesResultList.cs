using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FilesConverter.SalesConverters;

namespace FilesConverter.Sales
{
    public class SalesResultList
    {
        public List<SalesResult> ResultList { get; set; }
        public string PathForSaving { get; set; }
        
        
    }
}
