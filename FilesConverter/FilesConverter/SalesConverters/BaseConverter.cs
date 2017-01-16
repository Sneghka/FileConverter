using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FilesConverter.Sales;
using System.Data;
using System.IO;
using System.Net.Cache;
using FilesConverter.Result;

namespace FilesConverter.SalesConverters
{
    public abstract class BaseConverter
    {
        protected string Customer;
        protected DateTime Date;
        public string ColumnNames { get; set; }
        public string Request { get; set; }

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

        protected abstract List<IResultItem> ConvertRows(DataTable salesReport);


        public CommonResult ConvertSalesReport(string path)
        {
            var salesReport = new DataTable();
            var storedSales = new CommonResult();
            WorkWithExcel.ExcelFileToDataTable(out salesReport, path, Request);

            var columnNames = salesReport.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName);
            storedSales.FilePath = path;

            storedSales.GlobalErrorMessage = CheckColumnNames(columnNames);
            if (!string.IsNullOrEmpty(storedSales.GlobalErrorMessage))
            {
                return storedSales;
            }
            storedSales.Lines = ConvertRows(salesReport);
            storedSales.Name = Path.GetFileNameWithoutExtension(path);
            return storedSales;
        }

    }
}
