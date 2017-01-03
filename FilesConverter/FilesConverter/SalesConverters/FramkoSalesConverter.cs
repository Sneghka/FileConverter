using System;
using System.Collections.Generic;
using System.Data;
using FilesConverter.Sales;

namespace FilesConverter.SalesConverters
{
    public class FramkoSalesConverter : BaseConverter, ISalesConverter
    {

        public FramkoSalesConverter(DateTime data, string customer) : base( data, customer)
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
                    Distributor = "Фрамко",
                    Region = row["Область"].ToString(),
                    City = row["Город"].ToString(),
                    Date = _date.Date,
                    ItemName = row["Товар"].ToString(),
                    OKPO = row["КодОКПО"].ToString(),
                    DistributorsClientPlusAdress = row["Клиент"] + " " + row["Улица"],
                    Upakovki = Convert.ToInt32(row["Количество"])
                };
                storedSales.Add(storedSalesRow);
            }

            return storedSales;
        }

        
    }
}
