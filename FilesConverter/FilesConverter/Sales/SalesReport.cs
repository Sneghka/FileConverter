using System;
using System.Collections.Generic;
using FilesConverter.Distributors;

namespace FilesConverter.Sales

{
    public interface SalesReport
    {
        void ReadSalesReport(string path, string request, out List<BadmItem> storedFile);
       void CheckErrorSalesReport();
        void WriteDataToExcel(List<BadmItem> storedFile);

    }
}