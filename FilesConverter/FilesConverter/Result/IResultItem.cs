using System;
using FilesConverter.Errors;

namespace FilesConverter.Result
{
    public interface IResultItem
    {
        string Customer { get; set; }
        DateTime Date { get; set; }
        string ItemName { get; set; }

        string GetLineErrorMessage();
    }
}