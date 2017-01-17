using System;
using FilesConverter.Errors;

namespace FilesConverter.Result
{
    public interface IResultItem
    {

         //string ExcelColumnsName { get;  }

        string Customer { get; set; }
        DateTime Date { get; set; }
        string ItemName { get; set; }
       string LineErrorMessage();

        string[] GetColunmsNameForExcel();

    }
}