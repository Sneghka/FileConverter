using System;
using System.Collections.Generic;
using System.Data;
using FilesConverter.Sales;

namespace FilesConverter.SalesConverters
{
    public class FarmacoSalesConverter :  BaseConverter, ISalesConverter
    {
        public FarmacoSalesConverter(DateTime data, string customer) : base( data, customer)
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
