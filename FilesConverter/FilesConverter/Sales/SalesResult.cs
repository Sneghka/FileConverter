using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesConverter.Errors;

namespace FilesConverter.Sales
{
    public class SalesResult
    {
        

        public string Name { get; set; }
        public string FilePath { get; set; }
        public List<SalesResultItem> SaleLines { get; set; }

        public string Status
        {
            get
            {
                return IsSuccess ? "OK" : "Error";
            }
        }
        public string GlobalErrorMessage { get; set; }
        public List<ConvertationError> ErrorMessageList { get; set; }
        public bool IsSuccess => GlobalErrorMessage == "" && (ErrorMessageList?.Count ?? 0) == 0;

        
    }
}
