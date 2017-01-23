using System;
using System.Collections.Generic;
using System.Data;
using FilesConverter.Result;
using FilesConverter.Sales;

namespace FilesConverter.SalesConverters
{
    public class OptimaSalesConverter : BaseConverter, ICommonConverter
    {
        public OptimaSalesConverter(DateTime data, string customer) : base( data, customer)
        {
            ColumnNames = "Область,Город,Товар,Код товара,ОКПО,Дебитор доставки,Продажи шт";
            Request = "select * from [Страница 1$]";
        }

        protected override List<IResultItem> ConvertRows(DataTable salesReport)
        {
            var commonResultLines = new List<SalesResultItem>();
            foreach (DataRow row in salesReport.Rows)
            {
                if (Helper.IsRowEmpty(row)) continue;
                decimal i;
                var storedSalesRow = new SalesResultItem
                {
                    Customer = Customer,
                    Distributor = "Оптима",
                    Region = row["Область"].ToString(),
                    City = row["Город"].ToString(),
                    Date = Date.Date,
                    ItemName = row["Товар"].ToString(),
                    ItemCode = row["Код товара"].ToString(),
                    OKPO = row["ОКПО"].ToString(),
                    DistributorsClientPlusAdress = row["Дебитор доставки"].ToString(), // будет исправление после первого отчёта (пока нет колонки Адрес)
                    Upakovki = decimal.TryParse(row["Продажи шт"].ToString(), out i) ? i : (decimal?)null
                };
                commonResultLines.Add(storedSalesRow);
            }
            return new List<IResultItem>(commonResultLines);
        }
    }
}
