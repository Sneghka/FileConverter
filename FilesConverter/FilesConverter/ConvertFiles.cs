using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilesConverter.Sales;
using FilesConverter.SalesConverters;

namespace FilesConverter
{
    public class ConvertFiles
    {
        public List<SalesResult> CheckAndConvertSalesFiles(List<string> salesFile, DateTimePicker date,
            ComboBox customer)
        {
            var factory = new ConverterFactory(date.Value, customer.Text);
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
                            Status = "Error",
                            GlobalErrorMessage = "Incorrect file name"
                        });
                        continue;
                    }

                    var salesResult = converter.ConvertSalesReport(file, "select * from [Sheet1$]");
                    resultList.Add(salesResult);
                }
                catch (Exception e)
                {
                    resultList.Add(new SalesResult
                    {
                        FilePath = file,
                        Status = "Error",
                        GlobalErrorMessage = e.Message
                    });
                }
            }
            return resultList;
        }
    }
}
