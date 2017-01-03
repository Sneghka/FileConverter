using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilesConverter.SalesConverters;

namespace FilesConverter.Sales
{
    public class SalesResultList
    {
        public List<SalesResult> DistributorsSalesList { get; set; }
        public string PathForSaving { get; set; }

        
        public void CheckAndConvertSalesFiles(List<string> salesFile, DateTimePicker dateTimePicker, ComboBox boxCustomer) // перенесла в класс
        {
            
            var factory = new ConverterFactory(dateTimePicker.Value, boxCustomer.Text);
            List<SalesResult> tempList = new List<SalesResult>();

            foreach (var file in salesFile)
            {
                var converter = factory.GetConverter(file);
                var salesResult = new SalesResult();
                if (converter == null)
                {
                    salesResult.Status = "Error";
                   continue;
                }

                var dotIndex = file.LastIndexOf('.');
                var slashIndex = file.LastIndexOf('\\');
                
                salesResult.SaleLines = converter.ConvertSalesReport(file, "select * from [Sheet1$]");
                salesResult.Name = file.Substring(slashIndex + 1, dotIndex - slashIndex - 1);
                salesResult.Status = "Ok";

                tempList.Add(salesResult);
                
            }
            DistributorsSalesList = tempList;
        }

        public void ClearResult()
        {
            DistributorsSalesList.Clear();
            PathForSaving = string.Empty;

        }

    }
}
