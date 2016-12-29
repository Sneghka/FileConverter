using FilesConverter.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesConverter.Distributors
{
    public class VentaSalesConverter : SalesResultItem, ISalesConverter
    {

        private string _customer;
        private DateTime _date;

        public VentaSalesConverter(DateTime data, string customer)
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
                    Distributor = "Вента",
                    Region = row["Область"].ToString(),
                    City = row["Город"].ToString(),
                    Date = _date.Date,
                    ItemName = row["Товар"].ToString(),
                    ItemCode = row["Код товара"].ToString(),
                    OKPO = row["Окпо"].ToString(),
                    DistributorsClientPlusAdress = row["Клиент"] + " " + row["Адрес дост#"],
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
