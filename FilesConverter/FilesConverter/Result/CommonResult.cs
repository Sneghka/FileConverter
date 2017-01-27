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

        public void GetFolderForSavingIfUserNotChoosePathForSaving()
        {
            var dirName = new DirectoryInfo(Path.GetDirectoryName(FilePath));
            var folderForConvertedFiles = dirName.Name.ToLower() == "sales" ? "Преобразование Sales" : "Преобразование Stock";
            FolderForSaving = Path.Combine(dirName.ToString(), folderForConvertedFiles);
        }

        public void GetFolderForSavingIfUserChoosePathForSaving()
        {
            var dirName = new DirectoryInfo(Path.GetDirectoryName(FilePath)); // получаем путь откуда взяли файл
            var folderForConvertedFiles = dirName.Name.ToLower() == "sales" ? "Преобразование Sales" : "Преобразование Stock"; // создаём правильную папку для сохранения
            FolderForSaving = Path.Combine(FolderForSaving, folderForConvertedFiles);

        }
    }
}
