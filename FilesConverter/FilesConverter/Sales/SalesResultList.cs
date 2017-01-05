using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FilesConverter.SalesConverters;

namespace FilesConverter.Sales
{
    public class SalesResultList
    {
        public List<SalesResult> DistributorsSalesList { get; set; }
        public string PathForSaving { get; set; }


        public void CheckAndConvertSalesFiles(List<string> salesFile, DateTimePicker dateTimePicker, ComboBox boxCustomer)
        {

            var factory = new ConverterFactory(dateTimePicker.Value, boxCustomer.Text);
            List<SalesResult> tempList = new List<SalesResult>();

            foreach (var file in salesFile)
            {
                var salesResult = new SalesResult();

                var name = Path.GetFileNameWithoutExtension(file);
                var converter = factory.GetConverter(name);
                if (converter == null)
                {
                    salesResult.FilePath = file;
                    salesResult.Status = "Error";
                    salesResult.GlobalErrorMessage = "Incorrect file name.";
                    tempList.Add(salesResult);
                    continue;
                }
                salesResult = converter.ConvertSalesReport(file, "select * from [Sheet1$]");
                salesResult.Name = name;
                tempList.Add(salesResult);

            }
            DistributorsSalesList = tempList;
        }

        public void AddDataToGridView(DataGridView dataGridView1)
        {
            for (int i = 0; i < DistributorsSalesList.Count; i++)
            {
                var convertedFile = DistributorsSalesList[i];
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
                dataGridView1.Rows[i].Cells[1].Value = convertedFile.FilePath;
                dataGridView1.Rows[i].Cells[2].Value = convertedFile.Status;
                dataGridView1.Rows[i].Cells[3].Value = convertedFile.GlobalErrorMessage;

                dataGridView1.Rows[i].Cells[2].Style.ForeColor = convertedFile.IsSuccess ? Color.Green : Color.Red;

               /* if (convertedFile.IsSuccess) dataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.Green;
                if (!convertedFile.IsSuccess) dataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.Red;*/
                
            }
        }

        public void ClearResult()
        {
            DistributorsSalesList.Clear();
            PathForSaving = string.Empty;

        }

    }
}
