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
    public class BadmItemList : List<BadmItem>, SalesReport
    {
       
        public void ReadSalesReport(string path, string request, out List<BadmItem> storedFile )
        {
            DataTable salesReport = new DataTable();
            List<BadmItem> storedSales = new List<BadmItem>();

            WorkWithExcel.ExcelFileToDataTable(out salesReport, path, request );

            foreach (DataRow row in salesReport.Rows)
            {
                var storedSalesRow = new BadmItem
                {
                    Customer = "Джонсон и Джонсон",
                    Distributor = "Badm",
                    Region = row["Область"].ToString(),
                    City = row["Город"].ToString(),
                    Date = DateTime.Today,
                    ItemName = row["Товар"].ToString(),
                    ItemCode = row["Код товара"].ToString(),
                    OKPO = row["ОКПО клиента"].ToString(),
                    DistributorsClientPlusAdress = row["Клиент"] + ", " + row["Факт#адрес доставки"],
                    Upakovki = Convert.ToInt32(row["Количество"])
                };
                storedSales.Add(storedSalesRow);
            }

            storedFile = storedSales;

        }
        public void CheckErrorSalesReport()
        {

        }

        public void WriteDataToExcel(List<BadmItem> storedFile )
        {
            WorkWithExcel.WriteDataToExcel(storedFile);
        }
    }
}
