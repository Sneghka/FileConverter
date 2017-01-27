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
        public List<CommonResult> ConvertSalesFiles(List<string> filesList, DateTime date, string customer, ProgressBar progressBar, StatusBar statusBar)
        {
            var factory = new ConverterFactory(date.Date, customer);
            var resultList = new List<CommonResult>();

            progressBar.Minimum = 1;
            progressBar.Maximum = filesList.Count;
            progressBar.Value = 1;
            progressBar.Step = 1;

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
                    progressBar.PerformStep();
                    statusBar.Panels[0].Text = file;

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



        public void SendResultToExcel(List<CommonResult> commonResultList, List<ExchangeRule> rules, ProgressBar progressBar, StatusBar statusBar)
        {
            progressBar.Minimum = 1;
            progressBar.Maximum = commonResultList.Count;
            progressBar.Value = 1;
            progressBar.Step = 1;

            var quantLinesInExcelFile = 60000;

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
                    if (string.IsNullOrEmpty(commonResult.FolderForSaving))
                    {
                        commonResult.GetFolderForSavingIfUserNotChoosePathForSaving();
                    }

                    if (!string.IsNullOrEmpty(commonResult.FolderForSaving))
                    {
                        commonResult.GetFolderForSavingIfUserChoosePathForSaving();
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
                progressBar.PerformStep();
                statusBar.Panels[0].Text = commonResult.FilePath;
            }
        }
    }
}
