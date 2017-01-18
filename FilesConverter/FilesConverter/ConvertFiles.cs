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
    public class ConvertFiles 
    {
        public List<CommonResult> ConvertSalesFiles(List<string> salesFile, DateTime date, string customer)
        {
            var factory = new ConverterFactory(date.Date, customer);
            var resultList = new List<CommonResult>();

            foreach (var file in salesFile)
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
                                commonResult.GlobalErrorMessage = "Click row for details!";
                            }

                        }
                        commonResult.ErrorMessageList = errorMessageList;
                    }
                    resultList.Add(commonResult);
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

     

        public void SendResultToExcel(List<CommonResult> commonResultList, string folderForSaving, List<ExchangeRule> rules)
        {
            var quantLinesInExcelFile = 60000;

            foreach (var salesResult in commonResultList)
            {
                if (!salesResult.IsSuccess)
                {
                    continue;
                }

                if (rules.Count != 0)
                {
                    Helper.ChangeItemName(rules, salesResult.Lines);
                }
                var currentIndex = 0;
                var ostatokRowNumber = salesResult.Lines.Count;
                int j = 1;
                while (ostatokRowNumber > 0)
                {
                    var chosenFolder = folderForSaving;
                    var name = (j==1) ? salesResult.Name : salesResult.Name + "_" + j;
                    var pathForSaving = Path.Combine(chosenFolder, name);
                    var linesForWriting = ostatokRowNumber > quantLinesInExcelFile ? quantLinesInExcelFile : ostatokRowNumber;
                    var subList = salesResult.Lines.GetRange(currentIndex, linesForWriting);
                    currentIndex = currentIndex + linesForWriting;
                    ostatokRowNumber -= quantLinesInExcelFile;
                    WorkWithExcel.WriteDataToExcel(subList, pathForSaving);
                    j++;
                }
            }
        }
    }
}
