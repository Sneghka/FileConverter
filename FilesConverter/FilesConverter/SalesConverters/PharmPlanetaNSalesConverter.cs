using System;
using System.Collections.Generic;
using System.Data;
using FilesConverter.Sales;

namespace FilesConverter.SalesConverters
{
    public class PharmPlanetaNSalesConverter : BaseConverter, ISalesConverter
    {
        public PharmPlanetaNSalesConverter(DateTime data, string customer) : base( data, customer)
        {

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
                    Region = row["Область1"].ToString(), // из столбца F
                    City = row["Город1"].ToString(), // из столбца "G"
                    Date = _date.Date,
                    ItemName = row["Наименование"].ToString(),
                    ItemCode = row["Артикул МЦ"].ToString(),
                    OKPO = row[" ОКПО"].ToString(),
                    DistributorsClientPlusAdress = row["НаимКлиента_"] + " " + row["Адрес1"], //"Адрес" (из столбца "Н")
                    Upakovki = Convert.ToInt32(row["К-во"])
                };
                storedSales.Add(storedSalesRow);
            }

            return storedSales;
        }

      
    }
}
