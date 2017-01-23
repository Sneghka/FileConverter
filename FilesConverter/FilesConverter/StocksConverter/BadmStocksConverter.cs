using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesConverter.Result;
using FilesConverter.Sales;
using FilesConverter.Stock;
using FilesConverter.SalesConverters;

namespace FilesConverter.StocksConverter
{
    public class BadmStocksConverter : BaseConverter, ICommonConverter
    {
        public BadmStocksConverter(DateTime data, string customer) : base(data, customer)
        {
            ColumnNames = "Товар,Код товара,Филиал,Количество доступное";
            Request = "select * from [Badm$]";
        }

        protected override List<IResultItem> ConvertRows(DataTable salesReport)
        {
            var commonResultLines = new List<IResultItem>();
            foreach (DataRow row in salesReport.Rows)
            {
                if (Helper.IsRowEmpty(row)) continue;
                decimal i;
                var storedSalesRow = new StocksResultItem
                {
                    Customer = Customer,
                    Distributor = "Бадм",
                    AdressSklada = "Бадм" + " " + row["Филиал"],
                    Date = Date.Date,
                    ItemName = row["Товар"].ToString(),
                    ItemCode = row["Код товара"].ToString(),
                    Upakovki = decimal.TryParse(row["Количество доступное"].ToString(), out i) ? i : (decimal?)null

                };
                commonResultLines.Add(storedSalesRow);
            }
            return commonResultLines;
        }
    }
}
