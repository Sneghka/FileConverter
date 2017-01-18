using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FilesConverter.Result;
using FilesConverter.SalesConverters;

namespace FilesConverter.Sales
{
    public class CommonResultList 
    {
        public List<CommonResult> ResultList { get;} = new List<CommonResult>();
        public string PathForSaving { get; set; }
        
        
    }
}
