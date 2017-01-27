using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilesConverter.Errors;
using FilesConverter.Result;
using FilesConverter.Rules;
using FilesConverter.Sales;
using FilesConverter.SalesConverters;

namespace FilesConverter
{
    public class FileConverter
    {
        public delegate void OneFileProcessed(int filesQuantity, int counter);

        public delegate void FileNameChange(string fileName);

        public List<CommonResult> ConvertSalesFiles(List<string> filesList, DateTime date, string customer, OneFileProcessed oneFileProcessed, FileNameChange fileNameChange)
        {
            var factory = new ConverterFactory(date.Date, customer);
            var resultList = new List<CommonResult>();

            int counter = 1;
            foreach (var file in filesList)
            {
                try
                {
                    var name = Path.GetFileNameWithoutExtension(file);
                    var dirName = new DirectoryInfo(Path.GetDirectoryName(file)).Name;

                    var converter = factory.GetConverter(name, dirName);
                    if (converter == null)
                    {
                        resultList.Add(new CommonResult
                        {
                            FilePath = file,
                            GlobalErrorMessage = "Incorrect file name"
                        });
                        continue;
                    }

                    var commonResult = converter.ConvertSalesReport(file);

                    if (string.IsNullOrEmpty(commonResult.GlobalErrorMessage))
                    {
                        var errorMessageList = new List<ConvertationError>();
                        foreach (var line in commonResult.Lines)
                        {
                            var errorMessage = line.GetLineErrorMessage();
                            if (!string.IsNullOrEmpty(errorMessage))
                            {
                                var error = new ConvertationError();
                                error.RowNumber = commonResult.Lines.IndexOf(line) + 2;
                                error.ErrorMessage = errorMessage;
                                errorMessageList.Add(error);
                                commonResult.GlobalErrorMessage = Constants.ShowErrorDetails;
                            }
                        }
                        commonResult.ErrorMessageList = errorMessageList;
                    }
                    resultList.Add(commonResult);

                    oneFileProcessed(filesList.Count, counter);
                    counter++;
                    fileNameChange(file);
                }
                catch (Exception e)
                {
                    resultList.Add(new CommonResult
                    {
                        FilePath = file,
                        GlobalErrorMessage = e.Message
                    });
                }
            }
            return resultList;
        }



        public void SendResultToExcel(List<CommonResult> commonResultList, List<ExchangeRule> rules, OneFileProcessed oneFileProcessed, FileNameChange fileNameChange)
        {
            var quantLinesInExcelFile = 60000;
            int counter = 1;

            foreach (var commonResult in commonResultList)
            {
                if (!commonResult.IsSuccess)
                {
                    continue;
                }

                if (rules.Count != 0)
                {
                    Helper.ChangeItemName(rules, commonResult.Lines);
                }
                var currentIndex = 0;
                var ostatokRowNumber = commonResult.Lines.Count;
                int j = 1;
                while (ostatokRowNumber > 0)
                {
                    var dirName = new DirectoryInfo(Path.GetDirectoryName(commonResult.FilePath));
                    if (string.IsNullOrEmpty(commonResult.FolderForSaving))
                    {
                        commonResult.GetFolderForSaving(dirName.ToString());
                    }
                    if (!string.IsNullOrEmpty(commonResult.FolderForSaving))
                    {
                        commonResult.GetFolderForSaving(commonResult.FolderForSaving);
                    }
                    Directory.CreateDirectory(commonResult.FolderForSaving);

                    var name = (j == 1) ? commonResult.Name : commonResult.Name + "_" + j;
                    var pathForSaving = Path.Combine(commonResult.FolderForSaving, name);
                    var linesForWriting = ostatokRowNumber > quantLinesInExcelFile ? quantLinesInExcelFile : ostatokRowNumber;
                    var subList = commonResult.Lines.GetRange(currentIndex, linesForWriting);
                    currentIndex = currentIndex + linesForWriting;
                    ostatokRowNumber -= quantLinesInExcelFile;
                    WorkWithExcel.WriteDataToExcel(subList, pathForSaving);
                    j++;
                }
                oneFileProcessed(commonResultList.Count, counter);
                counter++;
                fileNameChange(commonResult.FilePath);
            }
        }
    }
}
