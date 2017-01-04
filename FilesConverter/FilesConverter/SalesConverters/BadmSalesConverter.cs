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
        public BadmSalesConverter(DateTime data, string customer) : base( data, customer)
        {
            ColumnNames = "Область,Город,Товар,Код товара,ОКПО клиента,Клиент,Факт#адрес доставки,Количество";
        }
        

       /* public List<string> GetNotFoundColunmNames(string path, string request)
        {
            WorkWithExcel.ExcelFileToDataTable(out salesReport, path, request);
            string[] columnNames = salesReport.Columns.Cast<DataColumn>()
                                .Select(x => x.ColumnName)
                                .ToArray();
            var incorrectColumns = CheckColumnNames(columnNames);

           return incorrectColumns;
        }*/

        public SalesResult ConvertSalesReport(string path, string request)
        {
            DataTable salesReport = new DataTable();

            SalesResult storedSales = new SalesResult();

            WorkWithExcel.ExcelFileToDataTable(out salesReport, path, request);

            string[] columnNames = salesReport.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();

            var сolumnsNotFoundList = CheckColumnNames(columnNames);
            if (сolumnsNotFoundList.Count > 0)
            {
                var newString = new StringBuilder();
                foreach (var col in сolumnsNotFoundList)
                {
                    newString.Append(col + " ");
                }
                storedSales.Information = "Не найдены колонки - " + newString;
                storedSales.FilePath = path;
                return storedSales;
            }

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
                storedSales.SaleLines.Add(storedSalesRow);
            }

            return storedSales;
        }
       
    }
}
