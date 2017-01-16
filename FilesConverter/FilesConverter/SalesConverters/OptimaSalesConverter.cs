using System;
using System.Collections.Generic;
using System.Data;
using FilesConverter.Sales;

namespace FilesConverter.SalesConverters
{
    public class OptimaSalesConverter : BaseConverter, ISalesConverter
    {
        public OptimaSalesConverter(DateTime data, string customer) : base( data, customer)
        {
            ColumnNames = "Область,Город,Товар,Код товара,ОКПО,Дебитор доставки,Продажи шт";
            Request = "select * from [Страница 1$]";
        }

        protected override List<SalesResultItem> ConvertRows(DataTable salesReport)
        {
            var property = new List<SalesResultItem>();
            foreach (DataRow row in salesReport.Rows)
            {
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
                    Upakovki = Convert.ToInt32(row["Продажи шт"])
                };
                property.Add(storedSalesRow);
            }
            return property;
        }
    }
}
