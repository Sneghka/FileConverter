using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesConverter.Sales;

namespace FilesConverter.Distributors
{
    public class FarmacoItemList : List<FarmacoItem>, SalesReport
    {
        public void ReadSalesReport(string path, string request, out List<FarmacoItem> storedFile)
        {
            DataTable salesReport = new DataTable();
            List<FarmacoItem> storedSales = new List<FarmacoItem>();

            WorkWithExcel.ExcelFileToDataTable(out salesReport, path, request);

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

        public void WriteDataToExcel(List<FarmacoItem> storedFile)
        {
            WorkWithExcel.WriteDataToExcel(storedFile);
        }
    }
}
