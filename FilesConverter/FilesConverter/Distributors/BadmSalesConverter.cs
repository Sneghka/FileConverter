using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesConverter.Sales;
using Excel = Microsoft.Office.Interop.Excel;

namespace FilesConverter.Distributors
{
    public class BadmSalesConverter : List<SalesResultItem>, ISalesReport
    {
       
        public List<SalesResultItem> ConvertSalesReport(string path, string request )
        {
            DataTable salesReport = new DataTable();
            List<SalesResultItem> storedSales = new List<SalesResultItem>();

            WorkWithExcel.ExcelFileToDataTable(out salesReport, path, request );

            foreach (DataRow row in salesReport.Rows)
         {
                var storedSalesRow = new SalesResultItem
                {
                    Customer = "Джонсон и Джонсон",
                    Distributor = "Badm",
                    Region = row["Область"].ToString(),
                    City = row["Город"].ToString(),
                    Date = DateTime.Today,
                    ItemName = row["Товар"].ToString(),
                    ItemCode = row["Код товара"].ToString(),
                    OKPO = row["ОКПО клиента"].ToString(),
                    DistributorsClientPlusAdress = row["Клиент"] + " " + row["Факт#адрес доставки"],
                    Upakovki = Convert.ToInt32(row["Количество"])
                };
                storedSales.Add(storedSalesRow);
            }

            return storedSales;
        }
        public void CheckErrorSalesReport()
        {

        }
    }
}
