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
        public string _customer;
        public DateTime _date;
        public string ColumnNames { get; set; }


        public BaseConverter(DateTime data, string customer)
        {
            _date = data;
            _customer = customer;
        }

        public string CheckColumnNames(string[] dtColumnNames)
        {
            List<string> colNamesNotFound = new List<string>();
            string message = string.Empty;
            string[] colListOfClass = ColumnNames.Split(',');

            foreach (var col in colListOfClass)

            {
                if (!dtColumnNames.Contains(col))
                {
                    colNamesNotFound.Add(col);
                }
            }

            if (colNamesNotFound.Count > 0)
            {
                var newString = new StringBuilder();
                foreach (var col in colNamesNotFound)
                {
                    newString.Append(col + " / ");
                }
                message = "Не найдены колонки - " + newString;
            }
            return message;
        }

        protected abstract List<SalesResultItem> ConvertRows(DataTable salesReport);

        public SalesResult ConvertSalesReport(string path, string request)
        {
            DataTable salesReport = new DataTable();
            SalesResult storedSales = new SalesResult();
            WorkWithExcel.ExcelFileToDataTable(out salesReport, path, request);

            string[] columnNames = salesReport.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();
            storedSales.FilePath = path;

            storedSales.GlobalErrorMessage = CheckColumnNames(columnNames);
            if (storedSales.GlobalErrorMessage != "")
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
