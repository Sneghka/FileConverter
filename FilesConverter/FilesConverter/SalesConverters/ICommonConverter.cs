using System.Collections.Generic;
using FilesConverter.Result;
using FilesConverter.Sales;

namespace FilesConverter.SalesConverters

{
    public interface ICommonConverter
    {
        CommonResult ConvertSalesReport(string path);
       
    }
}