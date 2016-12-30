using System;
using System.Collections.Generic;
using System.Data;
using FilesConverter.Sales;

namespace FilesConverter.SalesConverters
{
    public class OptimaSalesConverter : BaseConverter, ISalesConverter
    {
        public OptimaSalesConverter(DateTime data, string customer) : base( data, customer)
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
                    Distributor = "Оптима",
                    Region = row["Область"].ToString(),
                    City = row["Город"].ToString(),
                    Date = _date.Date,
                    ItemName = row["Товар"].ToString(),
                    ItemCode = row["Код товара"].ToString(),
                    OKPO = row["ОКПО"].ToString(),
                    DistributorsClientPlusAdress = row["Дебитор доставки"].ToString() , // будет исправление после первого отчёта (пока нет колонки Адрес)
                    Upakovki = Convert.ToInt32(row["Продажи шт"])
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
