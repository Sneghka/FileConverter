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
    public class FarmacoStocksConverter : BaseConverter, ICommonConverter
    {
        public FarmacoStocksConverter(DateTime data, string customer) : base(data, customer)
        {
            ColumnNames = "Наименование,Склад,Остаток";
            Request = "select * from [Report$]";
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
                    Distributor = "Фармако",
                    AdressSklada = "Фармако КИЕВ",
                    Date = Date.Date,
                    ItemName = row["Наименование"].ToString(),
                    Upakovki = decimal.TryParse(row["Остаток"].ToString(), out i) ? i : (decimal?)null

                };
                commonResultLines.Add(storedSalesRow);
            }
            return commonResultLines;
        }
    }
}
