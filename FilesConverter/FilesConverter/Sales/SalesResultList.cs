using System;
using System.Collections.Generic;
using System.Drawing;
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
                var salesResult = new SalesResult();

                var dotIndex = file.LastIndexOf('.');
                var slashIndex = file.LastIndexOf('\\');
                salesResult.FilePath = file;
                salesResult.Name = file.Substring(slashIndex + 1, dotIndex - slashIndex - 1);
                var converter = factory.GetConverter(salesResult.Name);
                
                if (converter == null)
                {
                    salesResult.UploadStatus = "Error";
                    salesResult.Information = "Incorrect file name.";
                    tempList.Add(salesResult);
                    continue;
                }
                salesResult = converter.ConvertSalesReport(file, "select * from [Sheet1$]");

                if (salesResult.Information.Contains("Не найдены колонки"))
                {
                    salesResult.UploadStatus = "Error";
                    tempList.Add(salesResult);
                    continue;
                }

                salesResult.UploadStatus = "Ok";
                tempList.Add(salesResult);
                
            }
            DistributorsSalesList = tempList;
        }

        public void AddDataToGridView( DataGridView dataGridView1)
        {
            for (int i = 0; i < DistributorsSalesList.Count; i++)
            {
                var convertedFile = DistributorsSalesList[i];
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
                dataGridView1.Rows[i].Cells[1].Value = convertedFile.FilePath;
                dataGridView1.Rows[i].Cells[2].Value = convertedFile.UploadStatus;
                dataGridView1.Rows[i].Cells[3].Value = convertedFile.Information;
                if (convertedFile.UploadStatus == "Ok") dataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.Green;
                if (convertedFile.UploadStatus == "Error") dataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.Red;
            }
        }

        public void ClearResult()
        {
            DistributorsSalesList.Clear();
            PathForSaving = string.Empty;

        }

    }
}
