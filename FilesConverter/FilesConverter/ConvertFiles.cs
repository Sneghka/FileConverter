using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilesConverter.Errors;
using FilesConverter.Rules;
using FilesConverter.Sales;
using FilesConverter.SalesConverters;

namespace FilesConverter
{
    public class ConvertFiles
    {
        public List<SalesResult> ConvertSalesFiles(List<string> salesFile, DateTime date, string customer)
        {
            var factory = new ConverterFactory(date.Date, customer);
            var resultList = new List<SalesResult>();

            foreach (var file in salesFile)
            {
                try
                {
                    var name = Path.GetFileNameWithoutExtension(file);
                    var converter = factory.GetConverter(name);
                    if (converter == null)
                    {
                        resultList.Add(new SalesResult
                        {
                            FilePath = file,
                            GlobalErrorMessage = "Incorrect file name"
                        });
                        continue;
                    }

                    var salesResult = converter.ConvertSalesReport(file, "select * from [Sheet1$]");

                    if (string.IsNullOrEmpty(salesResult.GlobalErrorMessage))
                    {
                        salesResult.ErrorMessageList = CheckSaleLinesErrors(salesResult);
                    }

                    resultList.Add(salesResult);
                }
                catch (Exception e)
                {
                    resultList.Add(new SalesResult
                    {
                        FilePath = file,
                        GlobalErrorMessage = e.Message
                    });
                }
            }
            return resultList;
        }

        private List<ConvertationError> CheckSaleLinesErrors(SalesResult salesResult)
        {
            var errorMessageList = new List<ConvertationError>();

            foreach (var line in salesResult.SaleLines)
            {
                var error = new ConvertationError();
                error.RowNumber = salesResult.SaleLines.IndexOf(line) + 2;
                var messageList = new List<string>();

                if (line?.Upakovki == null)
                {
                    messageList.Add(Constants.UpakovkiCellIsEmpty);
                }
                if ((line?.Region.Length ?? 0) < 2 || !Regex.IsMatch(line.Region, @"[a-zA-Zа-яА-ЯіІїЇєЄ]{2,}")) // @"^[a-zA-Zа-яА-ЯіІїЇєЄ.()\s.-]+$"
                {
                    messageList.Add(Constants.IncorrectRegionName);
                }
                if (Regex.IsMatch(line.DistributorsClientPlusAdress, "^(?!.*[a-zA-Zа-яА-ЯіІїЇєЄ]).*$")) // line contains gap after concat. Check if doesn't contain letters
                {
                    messageList.Add(Constants.IncorrectNameAndAdress);
                }
                if (messageList.Count != 0)
                {
                    error.ErrorMessage = string.Join("/", messageList);
                    errorMessageList.Add(error);
                    salesResult.GlobalErrorMessage = "Click row for details!";
                }
            }
            return errorMessageList;
        }

        public void SendResultToExcel(List<SalesResult> salesResultList, string folderForSaving, List<ExchangeRule> rules)
        {
            var quantLinesInExcelFile = 60000;

            foreach (SalesResult salesResult in salesResultList)
            {
                if (!salesResult.IsSuccess)
                {
                    continue;
                }

                if (rules.Count != 0)
                {
                    Helper.ChangeItemName(rules, salesResult.SaleLines);
                }

                
                var currentIndex = 0;
                var ostatokRowNumber = salesResult.SaleLines.Count;
                int j = 1;
                while (ostatokRowNumber > 0)
                {
                    var chosenFolder = folderForSaving;
                    var name = (j==1) ? salesResult.Name : salesResult.Name + "_" + j;
                    var pathForSaving = Path.Combine(chosenFolder, name);
                    var linesForWriting = ostatokRowNumber > quantLinesInExcelFile ? quantLinesInExcelFile : ostatokRowNumber;
                    var subList = salesResult.SaleLines.GetRange(currentIndex, linesForWriting);
                    currentIndex = currentIndex + linesForWriting;
                    ostatokRowNumber -= quantLinesInExcelFile;
                    WorkWithExcel.WriteDataToExcel(subList, pathForSaving);
                    j++;
                }
            }
        }
    }
}
