using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesConverter.Result;
using FilesConverter.SalesConverters;
using FilesConverter.Stock;

namespace FilesConverter.StocksConverter
{
    public class VentaStocksConverter : BaseConverter, ICommonConverter
    {
        public VentaStocksConverter(DateTime data, string customer) : base(data, customer)
        {
            ColumnNames = "Наименование Препарата,Тернополь,Днепр Опт,Днепр Розница,Киев,Львов,Одесса,Харьков";
            Request = "select * from [Sheet1$]";
        }

        protected override List<IResultItem> ConvertRows(DataTable stocksReport)
        {
            var columns = stocksReport.Columns;
            var commonResultLines = new List<IResultItem>();
            foreach (DataRow row in stocksReport.Rows)
            {
                if (Helper.IsRowEmpty(row)) continue;
                for (int j = 1; j < columns.Count; j++)
                {
                    decimal i;
                    var storedSalesRow = new StocksResultItem
                    {
                        Customer = Customer,
                        Distributor = "Вента",
                        AdressSklada = "Вента" + " " + columns[j].Caption,
                        Date = Date.Date,
                        ItemName = row["Наименование Препарата"].ToString(),
                        Upakovki = decimal.TryParse(row[columns[j].Caption].ToString(), out i) ? i : (decimal?)null

                    };
                    commonResultLines.Add(storedSalesRow);
                }
            }
            return commonResultLines;
        }
    }
}
