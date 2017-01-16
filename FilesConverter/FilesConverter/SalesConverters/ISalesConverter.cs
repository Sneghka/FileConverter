using System.Collections.Generic;
using FilesConverter.Sales;

namespace FilesConverter.SalesConverters

{
    public interface ISalesConverter
    {
        SalesResult ConvertSalesReport(string path);
       
    }
}