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
    public class PharmPlanetaNStocksConverter : BaseConverter, ICommonConverter
    {
        public PharmPlanetaNStocksConverter(DateTime data, string customer) : base(data, customer)
        {
            ColumnNames = "Название товара,Склад,Количество";
            Request = "select * from [остатки товара по поставщику (с$]";
        }

        protected override List<IResultItem> ConvertRows(DataTable salesReport)
        {
            var commonResultLines = new List<IResultItem>();
            foreach (DataRow row in salesReport.Rows)
            {
               if(Helper.IsRowEmpty(row)) continue;
                var skladStringArray = row["Склад"].ToString().Split(' ');
                var newArray = from w in skladStringArray
                    where w != "Винники" && w != "Фармпланета" && w != "ФП" && w != "Осн"
                    select w;
                var sklad = string.Join(" ", newArray);

                int i;
                var storedSalesRow = new StocksResultItem
                {
                    Customer = Customer,
                    Distributor = "Фармпланета",
                    AdressSklada = "Фармпланета" + " " + sklad,
                    Date = Date.Date,
                    ItemName = row["Название товара"].ToString(),
                    Upakovki = int.TryParse(row["Количество"].ToString(), out i) ? i : (int?)null

                };
                commonResultLines.Add(storedSalesRow);
            }
            return commonResultLines;
        }
    }
}
