using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesConverter.Sales;
using System.Data;

namespace FilesConverter.Distributors
{
    public class PharmPlanetaNSalesConverter : SalesResultItem, ISalesConverter
    {
        private string _customer;
        private DateTime _date;

        public PharmPlanetaNSalesConverter(DateTime data, string customer)
        {
            _date = data;
            _customer = customer;
        }

        public List<SalesResultItem> ConvertSalesReport(string path, string request)
        {
            DataTable salesReport = new DataTable();
            List<SalesResultItem> storedSales = new List<SalesResultItem>();

            WorkWithExcel.ExcelFileToDataTable(out salesReport, path, request);

            foreach (DataRow row in salesReport.Rows)
            {
                var storedSalesRow = new SalesResultItem
                {
                    Customer = _customer,
                    Distributor = "Фармпланета",
                    Region = row["Область"].ToString(), // из столбца F
                    City = row["Город"].ToString(), // из столбца "G"
                    Date = _date.Date,
                    ItemName = row["Наименование"].ToString(),
                    ItemCode = row["Код товара"].ToString(),
                    OKPO = row["ОКПО"].ToString(),
                    DistributorsClientPlusAdress = row["НаимКлиента"] + " " + row["Адрес"], //"Адрес" (из столбца "Н")
                    Upakovki = Convert.ToInt32(row["К-во"])
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
