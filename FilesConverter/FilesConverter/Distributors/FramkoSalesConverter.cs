using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesConverter.Sales;

namespace FilesConverter.Distributors
{
    public class FramkoSalesConverter : List<SalesResultItem>, ISalesReport
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
                    Distributor = "Framko",
                    Region = row["Область"].ToString(),
                    City = row["Город"].ToString(),
                    Date = DateTime.Today,
                    ItemName = row["Товар"].ToString(),
                    OKPO = row["КодОКПО"].ToString(),
                    DistributorsClientPlusAdress = row["Клиент"] + " " + row["Улица"],
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
