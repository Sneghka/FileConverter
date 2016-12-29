using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesConverter.Sales;

namespace FilesConverter.Distributors
{
    public class FarmacoSalesConverter : SalesResultItem, ISalesConverter
    {
        private string _customer;
        private DateTime _date;
        
        public FarmacoSalesConverter(DateTime data, string customer)
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
                    Distributor = "Фармако",
                    Region = row["Область"].ToString(),
                    Date = _date.Date,
                    ItemName = row["Наименование товара"].ToString(),
                    OKPO = row["ОКПО покупателя"].ToString(),
                    DistributorsClientPlusAdress = row["Покупатель"] + " " + row["Адрес доставки"],
                    Upakovki = Convert.ToInt32(row["Количество проданных уп#"])
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
