using System;
using System.Collections.Generic;
using FilesConverter.Distributors;

namespace FilesConverter.Sales

{
    public interface ISalesReport 
    {
        List<SalesResultItem> ConvertSalesReport(string path, string request);
        void CheckErrorSalesReport();
       

    }
}