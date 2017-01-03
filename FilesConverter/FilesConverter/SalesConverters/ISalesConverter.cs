using System.Collections.Generic;
using FilesConverter.Sales;

namespace FilesConverter.SalesConverters

{
    public interface ISalesConverter
    {
        List<SalesResultItem> ConvertSalesReport(string path, string request);
    }
}