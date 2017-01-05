﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesConverter.Sales
{
    public class SalesResult
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public List<SalesResultItem> SaleLines { get; set; }
        public string Status { get; set; }
        public string GlobalErrorMessage { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessageList { get; set; }

    }
}
