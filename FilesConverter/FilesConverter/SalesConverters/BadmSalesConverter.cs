using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using FilesConverter.Sales;
using DataTable = System.Data.DataTable;

namespace FilesConverter.SalesConverters
{
    public class BadmSalesConverter : BaseConverter, ISalesConverter
    {
        public BadmSalesConverter(DateTime data, string customer) : base(data, customer)
        {
            ColumnNames = "Область,Город,Товар,Код товара,ОКПО клиента,Клиент,Факт#адрес доставки,Количество";
        }


        public SalesResult ConvertSalesReport(string path, string request)
        {
            DataTable salesReport = new DataTable();

            SalesResult storedSales = new SalesResult();

            WorkWithExcel.ExcelFileToDataTable(out salesReport, path, request);

            string[] columnNames = salesReport.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();

            
            storedSales.GlobalErrorMessage = CheckColumnNames(columnNames);
            if (storedSales.GlobalErrorMessage != null)
            {
                storedSales.FilePath = path;
                storedSales.Status = "Error";
                return storedSales;
            }

            var property = new List<SalesResultItem>();
            foreach (DataRow row in salesReport.Rows)
            {
                var storedSalesRow = new SalesResultItem
                {
                    Customer = _customer,
                    Distributor = "БаДМ",
                    Region = row["Область"].ToString(),
                    City = row["Город"].ToString(),
                    Date = _date.Date,
                    ItemName = row["Товар"].ToString(),
                    ItemCode = row["Код товара"].ToString(),
                    OKPO = row["ОКПО клиента"].ToString(),
                    DistributorsClientPlusAdress = row["Клиент"] + " " + row["Факт#адрес доставки"],
                    Upakovki = Convert.ToInt32(row["Количество"])
                };
                property.Add(storedSalesRow);
            }
            storedSales.SaleLines = property;
            storedSales.FilePath = path;
            storedSales.Status = "OK";
            return storedSales;
        }

    }
}
