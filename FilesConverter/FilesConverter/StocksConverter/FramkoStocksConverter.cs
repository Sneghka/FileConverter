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
    public class FramkoStocksConverter : BaseConverter, ICommonConverter
    {
        public FramkoStocksConverter(DateTime data, string customer) : base(data, customer)
        {
            ColumnNames = "Товар,Склад,Остаток на конец";
            Request = "select * from [Оборот товаров$]";
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
                    Distributor = "Фрамко",
                    AdressSklada = "Фрамко" + " " + row["Склад"],
                    Date = Date.Date,
                    ItemName = row["Товар"].ToString(),
                   Upakovki = decimal.TryParse(row["Остаток на конец"].ToString(), out i) ? i : (decimal?)null

                };
                commonResultLines.Add(storedSalesRow);
            }
            return commonResultLines;
        }
    }
}
