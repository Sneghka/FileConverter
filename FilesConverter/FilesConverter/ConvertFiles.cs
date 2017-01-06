using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilesConverter.Errors;
using FilesConverter.Sales;
using FilesConverter.SalesConverters;

namespace FilesConverter
{
    public class ConvertFiles
    {
        public List<SalesResult> ConvertSalesFiles(List<string> salesFile, DateTime date,
            string customer)
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
                    var errorList = new ConvertationErrorsList();
                    //salesResult.ErrorMessageList = errorList.CheckSaleLinesErrors(salesResult);
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


      /*  public List<ConvertationError> CheckSaleLinesErrors(SalesResult salesResult)
        {
            
        }*/
    }
}
