using System;
using System.Collections.Generic;
using System.IO;
using FilesConverter.Errors;

namespace FilesConverter.Result
{
    public class CommonResult
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public List<IResultItem> Lines { get; set; }
        public string Status => IsSuccess ? "OK" : "Error";
        public string GlobalErrorMessage { get; set; }
        public List<ConvertationError> ErrorMessageList { get; set; }
        public bool IsSuccess => GlobalErrorMessage == "" && (ErrorMessageList?.Count ?? 0) == 0;
        public string FolderForSaving { get; set; }

        public void ChangeDate(DateTime day)
        {
            if (IsSuccess)
            {
                foreach (var lines in Lines)
                {
                    lines.Date = day;
                }
            }
        }


        public void ChangeCustomer(string customer)
        {
            if (IsSuccess)
            {
                foreach (var lines in Lines)
                {
                    lines.Customer = customer;
                }
            }
        }

        public void GetFolderForSaving(string pathPartOne)
        {
            var dirName = new DirectoryInfo(Path.GetDirectoryName(FilePath));
            var folderForConvertedFiles = dirName.Name.ToLower() == "sales" ? "Преобразование Sales" : "Преобразование Stock";

            FolderForSaving = pathPartOne.Contains("Преобразование") ? pathPartOne : Path.Combine(pathPartOne, folderForConvertedFiles);
        }
    }
}
