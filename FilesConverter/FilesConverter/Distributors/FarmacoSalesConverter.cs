using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesConverter.Sales;

namespace FilesConverter.Distributors
{
    public class FarmacoSalesConverter : List<SalesResultItem>, ISalesReport
    {
        public List<SalesResultItem> ConvertSalesReport(string path, string request)
        {
            DataTable salesReport = new DataTable();
            List<SalesResultItem> storedSales = new List<SalesResultItem>();

            WorkWithExcel.ExcelFileToDataTable(out salesReport, path, request);

            foreach (DataRow row in salesReport.Rows)
            {
                var storedSalesRow = new SalesResultItem
                {
                    Customer = "Джонсон и Джонсон",
                    Distributor = "Farmaco",
                    Region = row["Область"].ToString(),
                    Date = DateTime.Today,
                    ItemName = row["Наименование товара"].ToString(),
                    OKPO = row["ОКПО покупателя"].ToString(),
                    DistributorsClientPlusAdress = row["Покупатель"] + ", " + row["Адрес доставки"],
                    Upakovki = Convert.ToInt32(row["Количество проданных уп#"])
                };
                storedSales.Add(storedSalesRow);
            }
            return storedSales;
        }
        public void CheckErrorSalesReport()
        {

        }

        public void WriteDataToExcel(List<SalesResultItem> storedFile)
        {
            WorkWithExcel.WriteDataToExcel(storedFile, @"C:\Users\snizhana.nomirovska\Desktop\Jonson\Project\Converted Files\FarmacoSalesConverted.xls");
        }
    }
}
