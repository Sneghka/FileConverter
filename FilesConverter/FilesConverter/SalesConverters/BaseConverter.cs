using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FilesConverter.Sales;
using System.Data;

namespace FilesConverter.SalesConverters
{
    public abstract class BaseConverter
    {
        protected string Customer;
        protected DateTime Date;
        public string ColumnNames { get; set; }


        protected BaseConverter(DateTime data, string customer)
        {
            Date = data;
            Customer = customer;
        }

        public string CheckColumnNames(IEnumerable<string> dtColumnNames)
        {
            string message = string.Empty;
            string[] colListOfClass = ColumnNames.Split(',');

            var colNamesNotFound = colListOfClass.Where(col => !dtColumnNames.Contains(col)).ToList();

            if (colNamesNotFound.Count > 0)
            {
                var strJoin = string.Join("/", colNamesNotFound);
                message = "Не найдены колонки - " + strJoin;
            }
            return message;
        }

        protected abstract List<SalesResultItem> ConvertRows(DataTable salesReport);

        public SalesResult ConvertSalesReport(string path, string request)
        {
            var salesReport = new DataTable();
            var storedSales = new SalesResult();
            WorkWithExcel.ExcelFileToDataTable(out salesReport, path, request);

            var columnNames = salesReport.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName);
            storedSales.FilePath = path;

            storedSales.GlobalErrorMessage = CheckColumnNames(columnNames);
            if (!string.IsNullOrEmpty(storedSales.GlobalErrorMessage))
            {
                storedSales.Status = "Error";
                return storedSales;
            }
            storedSales.SaleLines = ConvertRows(salesReport);
            storedSales.Status = "OK";
            return storedSales;
        }

    }
}
